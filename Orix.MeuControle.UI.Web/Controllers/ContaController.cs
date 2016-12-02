using Orix.MeuControle.UI.Web.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Controllers
{
    public class ContaController : Controller
    {
        RestApi<AuthorizationViewModel> _restFull = new RestApi<AuthorizationViewModel>();

        // GET: Conta
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(ContaViewModel contaTela)
        {
            try
            {
                var responseToken = _restFull.RequestToken(new AuthorizationViewModel() {grant_type= "password", password = contaTela.Senha, username = contaTela.Usuario }, Method.POST, "Token");
               Token.setToken(responseToken.token_type + " " + responseToken.access_token);

                return Redirect("/Principal/Index");
            }
            catch (Exception ex)
            {
                return View();
                throw;
            }
            

                   
        }
    }
}