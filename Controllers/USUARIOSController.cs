using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/USUARIOS")]
    public class USUARIOSController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<object> ConsultarTodos()
        {
            return new clsUSUARIO().ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public object Consultar(int id)
        {
            return new clsUSUARIO().Consultar(id);
        }

        [HttpGet]
        [Route("ConsultarPorEmail")]
        public object ConsultarPorEmail(string email)
        {
            return new clsUSUARIO().ConsultarPorEmail(email);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] USUARIO entidad)
        {
            var clase = new clsUSUARIO { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] USUARIO entidad)
        {
            var clase = new clsUSUARIO { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] USUARIO entidad)
        {
            var clase = new clsUSUARIO { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
