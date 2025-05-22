using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/PROPIEDADES_MODELOs")]
    public class PROPIEDADES_MODELOsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PROPIEDADES_MODELO> ConsultarTodos() => new clsPROPIEDADES_MODELO().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public PROPIEDADES_MODELO Consultar(int id) => new clsPROPIEDADES_MODELO().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PROPIEDADES_MODELO entidad)
        {
            var clase = new clsPROPIEDADES_MODELO { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PROPIEDADES_MODELO entidad)
        {
            var clase = new clsPROPIEDADES_MODELO { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PROPIEDADES_MODELO entidad)
        {
            var clase = new clsPROPIEDADES_MODELO { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
