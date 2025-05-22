using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/SEDEs")]
    public class SEDEsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<SEDE> ConsultarTodos() => new clsSEDE().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public SEDE Consultar(int id) => new clsSEDE().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] SEDE entidad)
        {
            var clase = new clsSEDE { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] SEDE entidad)
        {
            var clase = new clsSEDE { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] SEDE entidad)
        {
            var clase = new clsSEDE { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
