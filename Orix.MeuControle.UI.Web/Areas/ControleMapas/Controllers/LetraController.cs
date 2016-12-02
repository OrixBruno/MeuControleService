using FastMapper;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using Orix.MeuControle.UI.Web;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using RestSharp;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class LetraController : Controller
    {
        RestApi<LetraViewModel> _restfull = new RestApi<LetraViewModel>();
        private const string CONTROLLER = "Letra";
        private const string ALFABETO = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        #region METODOS e CONTRUTOR
        public LetraController()
        {
            ViewBag.SelectLetras = new SelectList(ALFABETO.ToCharArray(), "Selecione...");
        }
        #endregion
        #region GET
        // GET: ControleMapas/Letra/Adicionar
        public ActionResult Adicionar()
        {           
            
            TempData.Add("Action", "Adicionar");
            return PartialView("_PartialLetraAdicionar");
        }
        // GET: ControleMapas/Letra/Editar/1
        public ActionResult Editar(int id)
        {
            try
            {
                TempData.Add("Action", "Editar");
                return PartialView("_PartialLetraAdicionar", _restfull.GetObjeto(CONTROLLER, "Get/" + id));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        // GET: ControleMapas/Letra/Lista
        public ActionResult Lista()
        {
            try
            {
                return PartialView("_PartialLista", _restfull.GetLista(CONTROLLER, "Get"));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }

        // GET: ControleMapas/Letra/Excluir/5
        public ActionResult Excluir(Int32 id)
        {
            try
            {
                _restfull.Request(null, Method.DELETE, CONTROLLER, "Delete/" + id);
                ViewBag.Status = "success";
                ViewBag.Message = "Letra excluida com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }

        }
        #endregion
        #region POST
        // POST: ControleMapas/Letra/Editar
        [HttpPost]
        public ActionResult Editar(LetraViewModel letraTela)
        {
            try
            {
                var response = _restfull.Request(letraTela, Method.PUT, CONTROLLER, "Put");
                ViewBag.Status = "success";
                ViewBag.Message = "Letra atualizada com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        // POST: ControleMapas/Letra/Adicionar
        [HttpPost]
        public ActionResult Adicionar(LetraViewModel letraTela)
        {
            try
            {
                _restfull.Request(letraTela, Method.POST, CONTROLLER, "Post");
                ViewBag.Message = "Letra adicionada com sucesso!" ;
                ViewBag.Status = "success";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }

        }
        #endregion
    }
}