using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/VENTAs")]
    public class VENTAsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<object> ConsultarTodos()
        {
            return new clsVENTA().ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public object Consultar(int id)
        {
            return new clsVENTA().Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] VENTA entidad)
        {
            var clase = new clsVENTA { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] VENTA entidad)
        {
            var clase = new clsVENTA { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] VENTA entidad)
        {
            var clase = new clsVENTA { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
