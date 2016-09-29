using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Orix.MeuControle.Service.Controllers;
using Microsoft.Owin.Cors;
using Orix.MeuControle.Service;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(Orix.MeuControle.ServiceOwin.Startup))]

namespace Orix.MeuControle.ServiceOwin
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

            //app.UseCors(CorsOptions.AllowAll);
            // Web API routes
            //config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/v1/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            ConfigureOAuth(app);
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        }
    }
}
