using Inmobiliaria.Clases;
using Microsoft.Ajax.Utilities;
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
            // ✅ Habilitar CORS globalmente (acepta todo)
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // ✅ Evitar errores de referencias circulares en objetos relacionados (Entity Framework)
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            json.SerializerSettings.ContractResolver = new DefaultContractResolver(); // <-- ESTA ES CLAVE

            // ✅ Validación de tokens para endpoints protegidos
            config.MessageHandlers.Add(new TokenValidationHandler());

            // ✅ Rutas por atributo
            config.MapHttpAttributeRoutes();

            // ✅ Ruta por defecto para compatibilidad
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
