using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/PROVEEDOREs")]
    public class PROVEEDOREsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PROVEEDORE> ConsultarTodos() => new clsPROVEEDORE().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public PROVEEDORE Consultar(int id) => new clsPROVEEDORE().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PROVEEDORE entidad)
        {
            var clase = new clsPROVEEDORE { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PROVEEDORE entidad)
        {
            var clase = new clsPROVEEDORE { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PROVEEDORE entidad)
        {
            var clase = new clsPROVEEDORE { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
