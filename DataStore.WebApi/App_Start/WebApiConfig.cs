using Newtonsoft.Json;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
using DataStore.WebApi.CustomAttributes;

namespace DataStore.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var originDomains = System.Configuration.ConfigurationManager.AppSettings["OriginDomains"];
            var cors = new EnableCorsAttribute(originDomains, "*", "*") { SupportsCredentials = true };

            config.EnableCors(cors);

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var authorisedRoles = System.Configuration.ConfigurationManager.AppSettings["AuthorisedRoles"];
            config.Filters.Add(new AuthorizeAttribute
            {
                Roles = authorisedRoles
            });

            config.Filters.Add(new ExceptionHandlingAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
