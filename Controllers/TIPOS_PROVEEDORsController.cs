using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/TIPOS_PROVEEDORs")]
    public class TIPOS_PROVEEDORsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<TIPOS_PROVEEDOR> ConsultarTodos() => new clsTIPOS_PROVEEDOR().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public TIPOS_PROVEEDOR Consultar(int id) => new clsTIPOS_PROVEEDOR().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] TIPOS_PROVEEDOR entidad)
        {
            var clase = new clsTIPOS_PROVEEDOR { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] TIPOS_PROVEEDOR entidad)
        {
            var clase = new clsTIPOS_PROVEEDOR { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] TIPOS_PROVEEDOR entidad)
        {
            var clase = new clsTIPOS_PROVEEDOR { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
