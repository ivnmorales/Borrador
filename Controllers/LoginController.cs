using Inmobiliaria.Models;
using Inmobiliaria.Clases;
using System.Linq;
using System.Web.Http;

namespace Inmobiliaria.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IHttpActionResult Ingresar(Login login)
        {
            if (login.Usuario == "admin" && login.Clave == "123")
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Usuario);
                return Ok(new LoginRespuesta
                {
                    Usuario = login.Usuario,
                    Perfil = "Administrador",
                    PaginaInicio = "LOGIN",
                    Autenticado = true,
                    Token = token,
                    Mensaje = "Acceso correcto"
                });
            }

            return Unauthorized();
        }
    }
}
