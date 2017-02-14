using Orix.MeuControle.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FastMapper;
using RestSharp;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using PagedList;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class SurdoController : Controller
    {
        private RestApi<SurdoViewModel> _restSurdo = new RestApi<SurdoViewModel>();
        private List<string> _listGenero = new List<string>() { "Homem", "Mulher", "Casal", "Irmão" };

        public SurdoController()
        {
            ViewBag.SelectGenero = new SelectList(_listGenero, "Selecione...");
            ViewBag.SelectMapas = new SelectList(new RestApi<MapaViewModel>().GetLista("Mapa", "Get"), "ID", "Letra.Letra,Numero", "Selecione...");
        }

        #region GET
        [HttpGet]
        public ActionResult Excluir(Int32 id)
        {
            try
            {
                _restSurdo.Request(null, Method.DELETE, "Surdo", "Delete/" + id);
                ViewBag.Status = "success";
                ViewBag.Message = "Surdo excluido com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        // GET: ControleMapas/Surdo/Adicionar
        public ActionResult Adicionar()
        {
            return View();
        }
        // GET: ControleMapas/Surdo/Lista
        public ActionResult Lista()
        {
            return View();
        }        
        public ActionResult ObterListaSurdosPagina(int? page, String coluna, String nome)
        {
            ViewBag.Coluna = coluna;
            ViewBag.Nome = nome;
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            try
            {
                if (coluna != null || nome != null)
                    return PartialView("_PartialSurdoLista", _restSurdo.GetLista("Surdo", "ListaOrdenada?coluna=" + coluna + "&texto=" + nome).ToPagedList(pageNumber, pageSize));

                return PartialView("_PartialSurdoLista", _restSurdo.GetLista("Surdo", "Get").ToPagedList(pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        // GET: ControleMapas/Surdo/Editar
        public ActionResult Editar(Int32 id)
        {
            
            try
            {
                var teste = _restSurdo.GetObjeto("Surdo", "Get/" + id);
                return View(teste);
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
        [HttpPost]
        public ActionResult Adicionar(SurdoViewModel dadoTela)
        {
            try
            {
                _restSurdo.Request(dadoTela, Method.POST, "Surdo","Post");
                ViewBag.Status = "success";
                ViewBag.Message = "Surdo cadastrado com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        [HttpPost]
        public ActionResult Editar(SurdoViewModel dadoTela)
        {
            try
            {
                _restSurdo.Request(dadoTela, Method.PUT, "Surdo","Put");
                ViewBag.Message = "Surdo atualizado com sucesso!";
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