using FastMapper;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class TerritorioController : Controller
    {
        RestApi<TerritorioViewModel> _territorioRest = new RestApi<TerritorioViewModel>();

        #region GET
        // GET: ControleMapas/Territorio/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ControleMapas/Territorio/Adicionar
        public ActionResult Adicionar()
        {
            TempData.Add("Action", "Adicionar");
            return PartialView("_PartialTerritorioAdicionar");
        }
        // GET: ControleMapas/Territorio/Lista
        public ActionResult Lista()
        {
            try
            {
                return PartialView("_PartialLista", _territorioRest.GetLista("Territorio","Get"));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        // GET: ControleMapas/Territorio/Editar/5
        public ActionResult Editar(int id)
        {
            try
            {
                TempData.Add("Action", "Editar");
                return PartialView("_PartialTerritorioAdicionar", _territorioRest.GetObjeto("Territorio", "Get/"+id));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        // GET: ControleMapas/Territorio/Excluir/5
        public ActionResult Excluir(Int32 id)
        {
            try
            {
                _territorioRest.Request(null, Method.DELETE, "Territorio", "Delete/"+id);
                ViewBag.Status = "success";
                ViewBag.Message = "Território excluido com sucesso!";
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
        // POST: ControleMapas/Territorio/Editar/5
        [HttpPost]
        public ActionResult Editar(TerritorioViewModel territorioTela)
        {
            try
            {
                _territorioRest.Request(territorioTela, Method.PUT, "Territorio","Put");
                ViewBag.Status = "success"; 
                ViewBag.Message = "Território atualizado com sucesso!"; ;
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            };
        }
        // POST: ControleMapas/Territorio/Adicionar
        [HttpPost]
        public ActionResult Adicionar(TerritorioViewModel territorioTela)
        {
            try
            {
                _territorioRest.Request(territorioTela, Method.POST, "Territorio","Post");
                ViewBag.Status = "success";
                ViewBag.Message = "Território cadastrado com sucesso!";
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
