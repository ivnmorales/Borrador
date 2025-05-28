using Borrador.Models;
using Borrador.Clases;
using System.Linq;
using System.Web.Http;
using Inmobiliaria.Clases;
using Inmobiliaria.Models;

namespace Borrador.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();

        [HttpPost]
        [Route("Ingresar")]
        public IHttpActionResult Ingresar(Login login)
        {
            // Validar con email y contraseña para USUARIO (tabla nueva con ROL)
            var usuario = db.USUARIOS
                .FirstOrDefault(u => u.EMAIL == login.Usuario && u.CONTRASENA == login.Clave);

            if (usuario != null)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Usuario);

                return Ok(new LoginRespuesta
                {
                    Usuario = usuario.EMAIL,
                    Perfil = usuario.ROL,
                    PaginaInicio = usuario.ROL == "ADMIN" ? "/Admin/dashboard.html" : "/Public/dashboard.html",
                    Autenticado = true,
                    Token = token,
                    Mensaje = "Acceso correcto"
                });
            }

            return Unauthorized();
        }
    }

}

    