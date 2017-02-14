using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using PagedList;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class EmprestimoController : Controller
    {
        private RestApi<EmprestimoViewModel> _restApi = new RestApi<EmprestimoViewModel>();
        private List<EmprestimoViewModel> _lstEmprestimosDisponiveis;
        private List<MapaViewModel> _listMapasDisponiveis;
        private IEnumerable<int> _listId;

        public EmprestimoController()
        {
            _lstEmprestimosDisponiveis = _restApi.GetLista("Emprestimo", "Get").Where(x => x.DataDevolucao == null).ToList();
            _listId = _lstEmprestimosDisponiveis.Select(x => x.IDMapa);
            _listMapasDisponiveis = new RestApi<MapaViewModel>().GetLista("Mapa", "Get").Where(x => !_listId.Contains(x.ID)).ToList();
            ViewBag.SelectMapas = new SelectList(_listMapasDisponiveis, "ID", "Numero", "Selecione...");
            ViewBag.SelectEmprestimos = new SelectList(_lstEmprestimosDisponiveis, "ID", "Mapa.Numero", "Selecione...");
            ViewBag.Emprestimos = _lstEmprestimosDisponiveis;
        }

        // GET: ControleMapas/Emprestimo/Principal
        public ActionResult Principal()
        {
            return View();
        }
        // GET: ControleMapas/Emprestimo/QtdMapaDisponivel
        public JsonResult QtdMapaDisponivel()
        {
            return Json(new { qtdMapaDisponivel = _listMapasDisponiveis.Count, qtdEmprestimos = _lstEmprestimosDisponiveis.Count }, JsonRequestBehavior.AllowGet);
        }
        // GET: ControleMapas/Emprestimo/DataEmprestimo/id
        public JsonResult DataEmprestimo(int id)
        {
            var dataEmprestimo = _lstEmprestimosDisponiveis.FirstOrDefault(x => x.ID == id).DataEmprestimo.ToShortDateString();
            return Json(new { dataEmprestimo = dataEmprestimo }, JsonRequestBehavior.AllowGet);
        }
        // GET: ControleMapas/Emprestimo/Detalhes/5
        public ActionResult Detalhes(int id)
        {
            return View();
        }
        // GET: ControleMapas/Emprestimo/Adicionar
        public ActionResult Adicionar()
        {
            return View();
        }
        public ActionResult Listar()
        {
            return View();
        }
        // GET: ControleMapas/Emprestimo/Devolucao
        public ActionResult Devolucao()
        {
            return View();
        }
        // GET: ControleMapas/Emprestimo/Adicionar
        public ActionResult FormularioDevolucao()
        {
            return PartialView("_PartialDevolucao");
        }
        // GET: ControleMapas/Emprestimo/Adicionar
        public ActionResult FormularioAdicionar()
        {
            TempData.Add("Action", "Adicionar");
            return PartialView("_PartialAdicionar");
        }
        public ActionResult SelectMapasDisponiveis()
        {
            _listMapasDisponiveis = new RestApi<MapaViewModel>().GetLista("Mapa", "Get").Where(x => !_listId.Contains(x.ID)).ToList();
            ViewBag.SelectMapas = new SelectList(_listMapasDisponiveis, "ID", "Numero", "Selecione...");
            return PartialView("_PartialSelectMapas");
        }
        public ActionResult SelectMapasDevolucao()
        {
            _lstEmprestimosDisponiveis = _restApi.GetLista("Emprestimo", "Get").Where(x => x.DataDevolucao == null).ToList();
            ViewBag.SelectEmprestimos = new SelectList(_lstEmprestimosDisponiveis, "ID", "Mapa.Numero", "Selecione...");
            return PartialView("_PartialSelectMapasDevo");
        }
        public ActionResult ObterLista(int? id)
        {
            try
            {
                return PartialView("_PartialListar", _restApi.GetLista("Emprestimo", "Get"));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        // GET: ControleMapas/Emprestimo/Edit/5
        public ActionResult Editar(int id)
        {
            TempData.Add("Action", "Editar");
            return View(_restApi.GetObjeto("Emprestimo", "Get/" + id));
        }

        // GET: ControleMapas/Emprestimo/Delete/5
        public ActionResult Excluir(int id)
        {
            try
            {
                _restApi.Request(null, Method.DELETE, "Emprestimo", "Delete/" + id);
                ViewBag.Status = "success";
                ViewBag.Message = "Empréstimo excluido com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }
        public ActionResult Mensagem(string mensagem)
        {
            ViewBag.Message = mensagem;
            ViewBag.Status = "danger";
            return PartialView("_PartialAlerta");
        }
        // POST: ControleMapas/Emprestimo/Adicionar
        [HttpPost]
        public ActionResult Adicionar(EmprestimoViewModel emprestimo)
        {
            try
            {
                _restApi.Request(emprestimo, Method.POST, "Emprestimo", "Post");
                ViewBag.Status = "success";
                ViewBag.Message = "Emprestimo adicionado com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }

        // POST: ControleMapas/Emprestimo/Editar
        [HttpPost]
        public ActionResult Editar(EmprestimoViewModel emprestimo)
        {
            var emprestimoAtualizar = _lstEmprestimosDisponiveis.FirstOrDefault(x => x.ID == emprestimo.ID);
            emprestimoAtualizar.DataDevolucao = emprestimo.DataDevolucao;
            //emprestimoAtualizar.DataEmprestimo = emprestimo.DataEmprestimo != null ? emprestimo.DataEmprestimo : emprestimoAtualizar.DataEmprestimo;

            try
            {
                _restApi.Request(emprestimoAtualizar, RestSharp.Method.PUT, "Emprestimo", "Put");
                ViewBag.Status = "success";
                ViewBag.Message = "Emprestimo atualizado com sucesso!";
                return PartialView("_PartialAlerta");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return PartialView("_PartialAlerta");
            }
        }

    }
}
