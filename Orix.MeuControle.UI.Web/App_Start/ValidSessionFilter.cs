using System.Web.Mvc;
using System.Web.Routing;

namespace Orix.MeuControle.UI.Web.App_Start
{
    internal class ValidSessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Token"] == null &&
                filterContext.RouteData.Values["controller"].ToString() != "Conta" &&
                filterContext.RouteData.Values["action"].ToString() != "Login")
            {
                var routes = new RouteValueDictionary
                    {
                        { "area",""},
                        { "controller", "Conta" },
                        { "action", "Login" }
                    };
                filterContext.Result = new RedirectToRouteResult(routes);
            }

            base.OnActionExecuting(filterContext);
        }
    }
}