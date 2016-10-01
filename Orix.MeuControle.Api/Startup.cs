using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(Orix.MeuControle.Api.Startup))]

namespace Orix.MeuControle.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            WebApiConfig.Register(config);


            ConfigureAuth(app);
        }
    }
}
