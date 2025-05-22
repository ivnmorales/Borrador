using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/CLIENTEs")]
    public class CLIENTEsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<CLIENTE> ConsultarTodos() => new clsCLIENTE().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public CLIENTE Consultar(int id) => new clsCLIENTE().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] CLIENTE entidad)
        {
            var clase = new clsCLIENTE { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] CLIENTE entidad)
        {
            var clase = new clsCLIENTE { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] CLIENTE entidad)
        {
            var clase = new clsCLIENTE { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
