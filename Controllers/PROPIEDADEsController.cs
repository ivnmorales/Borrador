using Borrador.Clases;
using Borrador.Models;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/propiedades")]
    public class PROPIEDADEsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var lista = new clsPROPIEDADE().ConsultarTodos();
            return Ok(lista);
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var propiedad = new clsPROPIEDADE().Consultar(id);
            return propiedad == null ? (IHttpActionResult)NotFound() : Ok(propiedad);
        }

        [HttpPost]
        [Route("Insertar")]
        public IHttpActionResult Insertar([FromBody] PROPIEDADE entidad)
        {
            if (entidad == null)
                return BadRequest("Datos inv�lidos para inserci�n.");

            var clase = new clsPROPIEDADE { entidad = entidad };
            var resultado = clase.Insertar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IHttpActionResult Actualizar([FromBody] PROPIEDADE entidad)
        {
            if (entidad == null)
                return BadRequest("Datos inv�lidos para actualizaci�n.");

            var clase = new clsPROPIEDADE { entidad = entidad };
            var resultado = clase.Actualizar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IHttpActionResult Eliminar([FromBody] PROPIEDADE entidad)
        {
            if (entidad == null || entidad.ID_PROPIEDAD <= 0)
                return BadRequest("ID inv�lido para eliminaci�n.");

            var clase = new clsPROPIEDADE { entidad = entidad };
            var resultado = clase.Eliminar();
            return resultado.StartsWith("Error") || resultado.Contains("no encontrada")
                ? (IHttpActionResult)BadRequest(resultado)
                : Ok(resultado);
        }
    }
}
