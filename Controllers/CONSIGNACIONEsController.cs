using Borrador.Clases;
using Borrador.Models;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/consignaciones")]
    public class CONSIGNACIONEsController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public IHttpActionResult ConsultarTodos()
        {
            var lista = new clsCONSIGNACIONE().ConsultarTodos();
            return Ok(lista);
        }

        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(int id)
        {
            var obj = new clsCONSIGNACIONE().Consultar(id);
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpPost]
        [Route("Insertar")]
        public IHttpActionResult Insertar([FromBody] CONSIGNACIONE entidad)
        {
            if (entidad == null)
                return BadRequest("Datos de entrada no válidos.");

            var clase = new clsCONSIGNACIONE { entidad = entidad };
            var resultado = clase.Insertar();

            if (resultado.Contains("insertado correctamente"))
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

        [HttpPut]
        [Route("Actualizar")]
        public IHttpActionResult Actualizar([FromBody] CONSIGNACIONE entidad)
        {
            if (entidad == null)
                return BadRequest("Datos no válidos para actualizar.");

            var clase = new clsCONSIGNACIONE { entidad = entidad };
            var resultado = clase.Actualizar();

            if (resultado.Contains("actualizada"))
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public IHttpActionResult Eliminar([FromBody] CONSIGNACIONE entidad)
        {
            if (entidad == null || entidad.ID_CONSIGNACION <= 0)
                return BadRequest("ID de consignación inválido.");

            var clase = new clsCONSIGNACIONE { entidad = entidad };
            var resultado = clase.Eliminar();

            if (resultado.Contains("eliminado correctamente"))
                return Ok(resultado);
            else
                return BadRequest(resultado);
        }
    }
}
