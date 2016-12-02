using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas
{
    public class ControleMapasAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ControleMapas";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ControleMapas_default",
                "ControleMapas/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}