using Inmobiliaria.Clases;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Borrador
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // ✅ Habilitar CORS para aceptar peticiones del frontend (cualquier origen, encabezado y método)
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // ✅ Evitar errores de serialización por referencias circulares
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
           

            // ✅ Agregar el handler de validación del token
            config.MessageHandlers.Add(new TokenValidationHandler());

            // ✅ Configuración de rutas por atributo
            config.MapHttpAttributeRoutes();

            // ✅ Ruta por defecto (fallback)
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
