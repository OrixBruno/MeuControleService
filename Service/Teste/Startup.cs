using Microsoft.Owin.Cors;
using Orix.MeuControle.Service.Controllers;
using Owin;
using System;
using System.Web.Http;

namespace Service.Teste
{
    public class Startup
    {
        Type TerritorioController = typeof(TerritorioController);
        Type LetraController = typeof(LetraController);
        Type MapaController = typeof(MapaController);
        Type SaidaController = typeof(SaidaController);

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;
            config.EnableCors();
            app.UseCors(CorsOptions.AllowAll);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}
