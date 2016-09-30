using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Orix.MeuControle.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");

            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        
    }
}
