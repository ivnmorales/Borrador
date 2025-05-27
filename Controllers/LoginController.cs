using Inmobiliaria.Models;
using Inmobiliaria.Clases;
using System.Linq;
using System.Web.Http;
using Borrador.Models;

namespace Inmobiliaria.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private INMOBILIARIAEntities db = new INMOBILIARIAEntities();

        [HttpPost]
        [Route("Ingresar")]
        public IHttpActionResult Ingresar(Login login)
        {
            // 🔁 Validar con email como usuario y identificacion como clave
            var empleado = db.EMPLEADOS
                .FirstOrDefault(e => e.EMAIL == login.Usuario && e.IDENTIFICACION == login.Clave);

            if (empleado != null)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Usuario);

                return Ok(new LoginRespuesta
                {
                    Usuario = empleado.NOMBRES + " " + empleado.APELLIDOS,
                    Perfil = empleado.CARGO,
                    PaginaInicio = "/Public/dashboard.html",
                    Autenticado = true,
                    Token = token,
                    Mensaje = "Acceso correcto"
                });
            }

            return Unauthorized();
        }
    }
}
