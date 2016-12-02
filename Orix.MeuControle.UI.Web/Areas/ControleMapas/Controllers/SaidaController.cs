using FastMapper;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class SaidaController : Controller
    {
        RestApi<SaidaViewModel> _saidaRest = new RestApi<SaidaViewModel>();

        #region GET
        // GET: ControleMapas/Saida
        public ActionResult Index()
        {
            return View();
        }

        // GET: ControleMapas/Saida/Adicionar
        public ActionResult Adicionar()
        {
            return PartialView("_PartialSaidaAdicionar");
        }
        // GET: ControleMapas/Saida/Lista
        public ActionResult Lista()
        {
            try
            {
                return PartialView("_PartialLista", _saidaRest.GetLista("Saida","Get"));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        // GET: ControleMapas/Saida/Editar/5
        public ActionResult Editar(int id)
        {
            try
            {
                TempData.Add("Action", "Editar");
                return PartialView("_PartialSaidaAdicionar", _saidaRest.GetObjeto("Saida", "Get/" + id));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }

        // GET: ControleMapas/Saida/Excluir/5
        public ActionResult Excluir(int id)
        {
            try
            {
                _saidaRest.Request(null, Method.DELETE, "Saida", "Delete/" + id);
                ViewBag.Status = "success";
                ViewBag.Message = "Saída excluida com sucesso!";
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
        // POST: ControleMapas/Saida/Adicionar
        [HttpPost]
        public ActionResult Adicionar(SaidaViewModel saidaTela)
        {
            try
            {
                _saidaRest.Request(saidaTela, Method.POST, "Saida","Post");
                ViewBag.Status = "success";
                ViewBag.Message = "Saída cadastrada com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }

        }

        // POST: ControleMapas/Saida/Editar/5
        [HttpPost]
        public ActionResult Editar(SaidaViewModel saidaTela)
        {
            try
            {
                _saidaRest.Request(saidaTela, Method.PUT, "Saida","Put");
                ViewBag.Status = "success";
                ViewBag.Message = "Saída atualizada com sucesso!";
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
