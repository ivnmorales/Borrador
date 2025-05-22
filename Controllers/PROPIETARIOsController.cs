using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/PROPIETARIOs")]
    public class PROPIETARIOsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PROPIETARIO> ConsultarTodos() => new clsPROPIETARIO().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public PROPIETARIO Consultar(int id) => new clsPROPIETARIO().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PROPIETARIO entidad)
        {
            var clase = new clsPROPIETARIO { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PROPIETARIO entidad)
        {
            var clase = new clsPROPIETARIO { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PROPIETARIO entidad)
        {
            var clase = new clsPROPIETARIO { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
