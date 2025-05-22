using Borrador.Clases;
using Borrador.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/PROYECTOs")]
    public class PROYECTOsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<PROYECTO> ConsultarTodos() => new clsPROYECTO().ConsultarTodos();

        [HttpGet]
        [Route("Consultar")]
        public PROYECTO Consultar(int id) => new clsPROYECTO().Consultar(id);

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PROYECTO entidad)
        {
            var clase = new clsPROYECTO { entidad = entidad };
            return clase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PROYECTO entidad)
        {
            var clase = new clsPROYECTO { entidad = entidad };
            return clase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PROYECTO entidad)
        {
            var clase = new clsPROYECTO { entidad = entidad };
            return clase.Eliminar();
        }
    }
}
