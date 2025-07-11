﻿using Borrador.Clases;
using Borrador.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Borrador.Controllers
{
    [RoutePrefix("api/UploadFiles")]
    public class UploadFilesController : ApiController
    {
        [HttpPost]
        [Route("Subir")]
        public async Task<HttpResponseMessage> GrabarArchivo(HttpRequestMessage request, string Datos, string Proceso)
        {
            clsUpload upload = new clsUpload
            {
                request = request,
                Datos = Datos,
                Proceso = Proceso
            };
            return await upload.GrabarArchivo(false);
        }

        [HttpGet]
        [Route("Consultar")]
        public HttpResponseMessage Get(string NombreImagen)
        {
            return new clsUpload().ConsultarArchivo(NombreImagen);
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<HttpResponseMessage> ActualizarArchivo(HttpRequestMessage request, string Datos, string Proceso)
        {
            clsUpload upload = new clsUpload
            {
                request = request,
                Datos = Datos,
                Proceso = Proceso
            };
            return await upload.GrabarArchivo(true);
        }

        [HttpDelete]
        [Route("Eliminar")]
        public HttpResponseMessage EliminarArchivo(string NombreImagen)
        {
            var resultado = new clsUpload().EliminarArchivo(NombreImagen);

            if (resultado == "OK")
                return Request.CreateResponse(HttpStatusCode.OK, "Imagen eliminada correctamente.");
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, resultado);
        }
        [HttpGet]
        [Route("ConsultarImagenes")]
        public IHttpActionResult ConsultarImagenes(int IdPropiedad)
        {
            using (var db = new INMOBILIARIAEntities())
            {
                var imagenes = db.IMAGENES_PROPIEDAD
                                 .Where(i => i.ID_PROPIEDAD == IdPropiedad)
                                 .Select(i => i.NOMBRE)
                                 .ToList();
                return Ok(imagenes);
            }
        }


    }
}
