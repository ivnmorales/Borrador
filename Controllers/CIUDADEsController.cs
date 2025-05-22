using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/CIUDADEs")]
    public class CIUDADEsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<CIUDADE> ConsultarTodos() => new clsCIUDADE().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public CIUDADE Consultar(int id) => new clsCIUDADE().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] CIUDADE entidad)
        {
            var clase = new clsCIUDADE { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] CIUDADE entidad)
        {
            var clase = new clsCIUDADE { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] CIUDADE entidad)
        {
            var clase = new clsCIUDADE { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
