using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.IdentityModel.Tokens;

namespace Inmobiliaria.Clases
{
    public class TokenValidationHandler : DelegatingHandler
    {
        private static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;

            if (!request.Headers.TryGetValues("Authorization", out var authzHeaders) || authzHeaders.Count() != 1)
                return false;

            var bearerToken = authzHeaders.FirstOrDefault();
            token = bearerToken != null && bearerToken.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)
                ? bearerToken.Substring(7)
                : bearerToken;

            return !string.IsNullOrEmpty(token);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpStatusCode statusCode;
            string token;

            // Omitir validación JWT para el endpoint de login (insensible a mayúsculas)
            string path = request.RequestUri.AbsolutePath.ToLower();
            if (path.StartsWith("/api/login/ingresar"))
            {
                return base.SendAsync(request, cancellationToken);
            }

            if (!TryRetrieveToken(request, out token))
            {
                statusCode = HttpStatusCode.Unauthorized;
                var response = request.CreateResponse(statusCode, new { mensaje = "Token no proporcionado" });
                return Task.FromResult(response);
            }

            try
            {
                var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
                var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
                var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
                var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));

                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;

                var validationParameters = new TokenValidationParameters
                {
                    ValidAudience = audienceToken,
                    ValidIssuer = issuerToken,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    LifetimeValidator = this.LifetimeValidator,
                    IssuerSigningKey = securityKey
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                Thread.CurrentPrincipal = principal;
                HttpContext.Current.User = principal;

                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenExpiredException)
            {
                statusCode = HttpStatusCode.Unauthorized;
                var response = request.CreateResponse(statusCode, new { mensaje = "Token expirado" });
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                statusCode = HttpStatusCode.Unauthorized;
                var response = request.CreateResponse(statusCode, new { mensaje = $"Token inválido: {ex.Message}" });
                return Task.FromResult(response);
            }
        }

        public bool LifetimeValidator(DateTime? notBefore, DateTime? expires, SecurityToken securityToken, TokenValidationParameters validationParameters)
        {
            return expires != null && DateTime.UtcNow < expires;
        }
    }
}
