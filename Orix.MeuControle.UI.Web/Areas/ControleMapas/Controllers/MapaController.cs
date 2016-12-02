using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using System;
using System.Web.Mvc;
using FastMapper;
using System.IO;
using Newtonsoft.Json;
using System.Web;
using RestSharp;
using System.Collections.Generic;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.Controllers
{
    public class MapaController : Controller
    {
        private RestApi<MapaViewModel> _mapaRest = new RestApi<MapaViewModel>();
        private List<string> _listCores = new List<string>() { "Azul", "Vermelho", "Verde", "Cinza", "Azul Escuro", "Verde Escuro" };

        public MapaController()
        {
            ViewBag.SelectLetras = new SelectList(new RestApi<LetraViewModel>().GetLista("Letra", "Get"), "ID", "Letra", "Selecione...");
            ViewBag.SelectSaidas = new SelectList(new RestApi<SaidaViewModel>().GetLista("Saida", "Get"), "ID", "Local", "Selecione...");
            ViewBag.SelectTerritorios = new SelectList(new RestApi<TerritorioViewModel>().GetLista("Territorio", "Get"), "ID", "Nome", "Selecione...");
            ViewBag.SelectCores = new SelectList(_listCores, "Selecione...");
        }

        #region GET
        public ActionResult Adicionar()
        {
            return View();
        }
        public ActionResult Editar(Int32 id)
        {
            return View(_mapaRest.GetObjeto("Mapa", "Get/" + id));
        }
        public ActionResult Excluir(Int32 id)
        {
            try
            {
                _mapaRest.Request(null, Method.DELETE, "Mapa", "Delete/" + id);
                ViewBag.Message = "Mapa excluido com sucesso!";
                ViewBag.Status = "success";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
            }
            return PartialView("_PartialAlerta");
        }
        public ActionResult Listar()
        {
            try
            {
                return View(_mapaRest.GetLista("Mapa", "Get"));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Status = "danger";
                return View();
            }
        }
        public ActionResult Visualizar(int id)
        {
            try
            {
                return PartialView("_PartialVisualizar", _mapaRest.GetObjeto("Mapa","Get/" + id));
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
        public ActionResult Adicionar(MapaViewModel mapaTela)
        {
            try
            {
                _mapaRest.Request(mapaTela, Method.POST, "Mapa", "Post");
                ViewBag.Status = "success";
                ViewBag.Message = "Mapa cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                ViewBag.Status = "danger";
                ViewBag.Message = ex.Message;
            }
            return PartialView("_PartialAlerta");
        }
        [HttpPost]
        public ActionResult AdicionarImagem()
        {
            var file = Request.Files["Imagem"];
            var id = Request.Form["Id"];

            return null;
        }
        [HttpPost]
        public ActionResult Editar(MapaViewModel mapaTela)
        {
            try
            {
                _mapaRest.Request(mapaTela, Method.PUT, "Mapa", "Put");
                ViewBag.Status = "success";
                ViewBag.Message = "Mapa atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                ViewBag.Status = "danger";
                ViewBag.Message = ex.Message;
            }
            return PartialView("_PartialAlerta");
        }
        #endregion

        #region IMPRESSAO
        public ActionResult Impressao()
        {
            return View();
        }
        public ActionResult ConsultarMapa(String letra, String codigo)
        {
            var json = new
            {
                Letra = "",
                Codigo = 10
            };

            return PartialView("_PartialMapaImprimir", json);
        }
        #endregion

        #region CONFIGURACOES
        public ActionResult Configuracoes()
        {
            return View();
        }

        public ActionResult ListaMunicipios()
        {
            return View();
        }
        #endregion
    }
}