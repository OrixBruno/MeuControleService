using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index()
        {
            //return Session["Token"] != null ? Redirect("ControleMapas/Home") : Redirect("Conta/Login");
            return Redirect("/ControleMapas/Home");
        }
    }
}