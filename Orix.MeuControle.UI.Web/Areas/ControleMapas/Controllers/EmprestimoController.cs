using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
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
        public EmprestimoController()
        {
            _lstEmprestimosDisponiveis = _restApi.GetLista("Emprestimo", "Get").Where(x => x.DataDevolucao == null).ToList();
            var listId = _lstEmprestimosDisponiveis.Select(x => x.IDMapa);
            _listMapasDisponiveis = new RestApi<MapaViewModel>().GetLista("Mapa", "Get").Where(x => !listId.Contains(x.ID)).ToList();
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
            return PartialView("_PartialAdicionar");
        }
        // GET: ControleMapas/Emprestimo/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // GET: ControleMapas/Emprestimo/Delete/5
        public ActionResult Excluir(int id)
        {
            return View();
        }

        // POST: ControleMapas/Emprestimo/Adicionar
        [HttpPost]
        public ActionResult Adicionar(EmprestimoViewModel emprestimo)
        {
            try
            {
                _restApi.Request(emprestimo, RestSharp.Method.POST, "Emprestimo", "Post");
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

        // POST: ControleMapas/Emprestimo/Delete/5
        [HttpPost]
        public ActionResult Excluir(int id, EmprestimoViewModel collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
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
