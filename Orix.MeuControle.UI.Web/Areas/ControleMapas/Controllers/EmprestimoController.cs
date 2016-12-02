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
        RestApi<EmprestimoViewModel> _restApi = new RestApi<EmprestimoViewModel>();
        private void ListaMapa()
        {
            TempData.Add("SelectMapas", new SelectList(new RestApi<MapaViewModel>().GetLista("Mapa", "Get"), "ID", "Numero", "Selecione..."));
        }
        #region GET
        // GET: ControleMapas/Emprestimo/Principal
        public ActionResult Principal()
        {
            ListaMapa();
            return View();
        }

        // GET: ControleMapas/Emprestimo/Details/5
        public ActionResult Detalhes(int id)
        {
            return View();
        }

        // GET: ControleMapas/Emprestimo/Create
        public ActionResult Adicionar()
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
        #endregion

        // POST: ControleMapas/Emprestimo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: ControleMapas/Emprestimo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: ControleMapas/Emprestimo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
