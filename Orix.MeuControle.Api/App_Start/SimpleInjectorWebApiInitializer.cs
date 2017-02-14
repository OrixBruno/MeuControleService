[assembly: WebActivator.PostApplicationStartMethod(typeof(Orix.MeuControle.Api.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace Orix.MeuControle.Api.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using Repository.Contracts;
    using Repository.Implementation;
    using SimpleInjector.Extensions.ExecutionContextScoping;
    using Owin;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static Container Initialize()
        {
            var container = new Container(); 
            InitializeContainer(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                  new SimpleInjectorWebApiDependencyResolver(container);
            return container;
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IAutenticacaoRepository, AutenticacaoRepository>();
            container.Register<IEmprestimoRepository, EmprestimoRepository>();
            container.Register<ILetraRepository, LetraRepository>();
            container.Register<IMapaRepository, MapaRepository>();
            container.Register<ISaidaRepository, SaidaRepository>();
            container.Register<ISurdoRepository, SurdoRepository>();
            container.Register<ITerritorioRepository, TerritorioRepository>();
        }
    }
}