using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Borrador.Clases;

namespace Borrador.Clases
{
    public class clsUpload
    {
        public HttpRequestMessage request { get; set; }
        public string Datos { get; set; }
        public string Proceso { get; set; }

        public async Task<HttpResponseMessage> GrabarArchivo(bool Actualizar)
        {
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/Archivos");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await request.Content.ReadAsMultipartAsync(provider);
                List<string> Archivos = new List<string>();
                string errores = "";

                foreach (var file in provider.FileData)
                {
                    string fileName = file.Headers.ContentDisposition.FileName?.Trim('"');
                    fileName = Path.GetFileName(fileName);
                    string filePath = Path.Combine(root, fileName);

                    if (File.Exists(filePath))
                    {
                        if (Actualizar)
                        {
                            File.Delete(filePath);
                            File.Move(file.LocalFileName, filePath);
                        }
                        else
                        {
                            File.Delete(file.LocalFileName);
                            errores += $"El archivo {fileName} ya existe. ";
                        }
                    }
                    else
                    {
                        File.Move(file.LocalFileName, filePath);
                        Archivos.Add(fileName);
                    }
                }

                if (Archivos.Count > 0)
                {
                    string respuesta = ProcesarArchivos(Archivos);
                    return request.CreateResponse(HttpStatusCode.OK, respuesta);
                }
                else if (!string.IsNullOrEmpty(errores))
                {
                    return request.CreateErrorResponse(HttpStatusCode.Conflict, errores);
                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.BadRequest, "No se subieron archivos válidos.");
                }
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error al cargar el archivo: " + ex.Message);
            }
        }

        public HttpResponseMessage ConsultarArchivo(string NombreArchivo)
        {
            try
            {
                string Ruta = HttpContext.Current.Server.MapPath("~/Archivos");
                string Archivo = Path.Combine(Ruta, NombreArchivo);

                if (File.Exists(Archivo))
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StreamContent(new FileStream(Archivo, FileMode.Open, FileAccess.Read))
                    };
                    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = NombreArchivo
                    };
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    return response;
                }
                else
                {
                    return request.CreateErrorResponse(HttpStatusCode.NotFound, "Archivo no encontrado");
                }
            }
            catch (Exception ex)
            {
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error al consultar el archivo: " + ex.Message);
            }
        }

        private string ProcesarArchivos(List<string> Archivos)
        {
            switch (Proceso.ToUpper())
            {
                case "IMAGEN":
                    var imagenes = new clsIMAGENES_PROPIEDAD
                    {
                        IdPropiedad = Datos,
                        Archivos = Archivos
                    };
                    return imagenes.GrabarImagenes();
                default:
                    return "Proceso no válido";
            }
        }
    }
}
