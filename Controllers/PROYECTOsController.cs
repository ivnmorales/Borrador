using Borrador.Clases;
using Borrador.Models;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/proyectos")]
    public class PROYECTOsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var lista = new clsPROYECTO().ConsultarTodos();
            return Ok(lista);
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var proyecto = new clsPROYECTO().Consultar(id);
            return proyecto == null ? (IHttpActionResult)NotFound() : Ok(proyecto);
        }

        [HttpPost]
        [Route("Insertar")]
        public IHttpActionResult Insertar([FromBody] PROYECTO entidad)
        {
            if (entidad == null)
                return BadRequest("Datos inv�lidos.");

            var clase = new clsPROYECTO { entidad = entidad };
            var resultado = clase.Insertar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IHttpActionResult Actualizar([FromBody] PROYECTO entidad)
        {
            if (entidad == null)
                return BadRequest("Datos inv�lidos.");

            var clase = new clsPROYECTO { entidad = entidad };
            var resultado = clase.Actualizar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IHttpActionResult Eliminar([FromBody] PROYECTO entidad)
        {
            if (entidad == null || entidad.ID_PROYECTO <= 0)
                return BadRequest("ID inv�lido.");

            var clase = new clsPROYECTO { entidad = entidad };
            var resultado = clase.Eliminar();
            return resultado.StartsWith("Error") ? (IHttpActionResult)BadRequest(resultado) : Ok(resultado);
        }
    }
}
