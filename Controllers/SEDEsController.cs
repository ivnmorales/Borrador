using Borrador.Clases;
using Borrador.Models;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/sedes")]
    public class SEDEsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var lista = new clsSEDE().ConsultarTodos();
            return Ok(lista);
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var sede = new clsSEDE().Consultar(id);
            return sede == null ? (IHttpActionResult)NotFound() : Ok(sede);
        }

        [HttpPost]
        [Route("Insertar")]
        public IHttpActionResult Insertar([FromBody] SEDE entidad)
        {
            if (entidad == null)
                return BadRequest("Datos inv�lidos.");

            var clase = new clsSEDE { entidad = entidad };
            var resultado = clase.Insertar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IHttpActionResult Actualizar([FromBody] SEDE entidad)
        {
            if (entidad == null)
                return BadRequest("Datos inv�lidos.");

            var clase = new clsSEDE { entidad = entidad };
            var resultado = clase.Actualizar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IHttpActionResult Eliminar([FromBody] SEDE entidad)
        {
            if (entidad == null || entidad.ID_SEDE <= 0)
                return BadRequest("ID inv�lido.");

            var clase = new clsSEDE { entidad = entidad };
            var resultado = clase.Eliminar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }
    }
}
