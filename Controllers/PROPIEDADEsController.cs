using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/PROPIEDADEs")]
    public class PROPIEDADEsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PROPIEDADE> ConsultarTodos() => new clsPROPIEDADE().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public PROPIEDADE Consultar(int id) => new clsPROPIEDADE().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PROPIEDADE entidad)
        {
            var clase = new clsPROPIEDADE { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PROPIEDADE entidad)
        {
            var clase = new clsPROPIEDADE { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PROPIEDADE entidad)
        {
            var clase = new clsPROPIEDADE { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
