using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/DETALLES_ORDENs")]
    public class DETALLES_ORDENsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<DETALLES_ORDEN> ConsultarTodos() => new clsDETALLES_ORDEN().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public DETALLES_ORDEN Consultar(int id) => new clsDETALLES_ORDEN().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] DETALLES_ORDEN entidad)
        {
            var clase = new clsDETALLES_ORDEN { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] DETALLES_ORDEN entidad)
        {
            var clase = new clsDETALLES_ORDEN { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] DETALLES_ORDEN entidad)
        {
            var clase = new clsDETALLES_ORDEN { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
