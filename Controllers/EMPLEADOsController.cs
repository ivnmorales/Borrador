using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/EMPLEADOs")]
    public class EMPLEADOsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<EMPLEADO> ConsultarTodos() => new clsEMPLEADO().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public EMPLEADO Consultar(int id) => new clsEMPLEADO().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] EMPLEADO entidad)
        {
            var clase = new clsEMPLEADO { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] EMPLEADO entidad)
        {
            var clase = new clsEMPLEADO { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] EMPLEADO entidad)
        {
            var clase = new clsEMPLEADO { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
