using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/tipos_visita")]
    public class TIPOS_VISITAsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<object> ConsultarTodos()
        {
            return new clsTIPOS_VISITA().ConsultarTodos();
        }

        [HttpGet]
        [Route("Consultar")]
        public object Consultar(int id)
        {
            return new clsTIPOS_VISITA().Consultar(id);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] TIPOS_VISITA entidad)
        {
            var clase = new clsTIPOS_VISITA { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] TIPOS_VISITA entidad)
        {
            var clase = new clsTIPOS_VISITA { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] TIPOS_VISITA entidad)
        {
            var clase = new clsTIPOS_VISITA { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
