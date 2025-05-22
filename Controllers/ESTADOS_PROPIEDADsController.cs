using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/ESTADOS_PROPIEDADs")]
    public class ESTADOS_PROPIEDADsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<ESTADOS_PROPIEDAD> ConsultarTodos() => new clsESTADOS_PROPIEDAD().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public ESTADOS_PROPIEDAD Consultar(int id) => new clsESTADOS_PROPIEDAD().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ESTADOS_PROPIEDAD entidad)
        {
            var clase = new clsESTADOS_PROPIEDAD { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] ESTADOS_PROPIEDAD entidad)
        {
            var clase = new clsESTADOS_PROPIEDAD { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] ESTADOS_PROPIEDAD entidad)
        {
            var clase = new clsESTADOS_PROPIEDAD { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
