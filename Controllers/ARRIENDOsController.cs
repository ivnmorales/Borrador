using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/ARRIENDOs")]
    public class ARRIENDOsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<ARRIENDO> ConsultarTodos() => new clsARRIENDO().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public ARRIENDO Consultar(int id) => new clsARRIENDO().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ARRIENDO entidad)
        {
            var clase = new clsARRIENDO { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] ARRIENDO entidad)
        {
            var clase = new clsARRIENDO { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] ARRIENDO entidad)
        {
            var clase = new clsARRIENDO { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
