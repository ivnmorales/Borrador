using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/CONSIGNACIONEs")]
    public class CONSIGNACIONEsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<CONSIGNACIONE> ConsultarTodos() => new clsCONSIGNACIONE().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public CONSIGNACIONE Consultar(int id) => new clsCONSIGNACIONE().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] CONSIGNACIONE entidad)
        {
            var clase = new clsCONSIGNACIONE { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] CONSIGNACIONE entidad)
        {
            var clase = new clsCONSIGNACIONE { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] CONSIGNACIONE entidad)
        {
            var clase = new clsCONSIGNACIONE { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
