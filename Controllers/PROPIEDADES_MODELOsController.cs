using Borrador.Clases;
using Borrador.Models;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/propiedades_modelo")]
    public class PROPIEDADES_MODELOsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var lista = new clsPROPIEDADES_MODELO().ConsultarTodos();
            return Ok(lista);
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var entidad = new clsPROPIEDADES_MODELO().Consultar(id);
            return entidad == null ? (IHttpActionResult)NotFound() : Ok(entidad);
        }

        [HttpPost]
        [Route("Insertar")]
        public IHttpActionResult Insertar([FromBody] PROPIEDADES_MODELO entidad)
        {
            if (entidad == null)
                return BadRequest("Datos no v�lidos para insertar.");

            var clase = new clsPROPIEDADES_MODELO { entidad = entidad };
            var resultado = clase.Insertar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IHttpActionResult Actualizar([FromBody] PROPIEDADES_MODELO entidad)
        {
            if (entidad == null)
                return BadRequest("Datos no v�lidos para actualizar.");

            var clase = new clsPROPIEDADES_MODELO { entidad = entidad };
            var resultado = clase.Actualizar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IHttpActionResult Eliminar([FromBody] PROPIEDADES_MODELO entidad)
        {
            if (entidad == null || entidad.ID_PROPIEDAD <= 0)
                return BadRequest("ID inv�lido para eliminar.");

            var clase = new clsPROPIEDADES_MODELO { entidad = entidad };
            var resultado = clase.Eliminar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }
    }
}
