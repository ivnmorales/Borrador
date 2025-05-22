using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/ORDENES_COMPRAs")]
    public class ORDENES_COMPRAsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<ORDENES_COMPRA> ConsultarTodos() => new clsORDENES_COMPRA().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public ORDENES_COMPRA Consultar(int id) => new clsORDENES_COMPRA().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ORDENES_COMPRA entidad)
        {
            var clase = new clsORDENES_COMPRA { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] ORDENES_COMPRA entidad)
        {
            var clase = new clsORDENES_COMPRA { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] ORDENES_COMPRA entidad)
        {
            var clase = new clsORDENES_COMPRA { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
