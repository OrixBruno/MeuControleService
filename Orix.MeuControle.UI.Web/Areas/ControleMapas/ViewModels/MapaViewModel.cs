using Orix.MeuControle.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels
{
    public class MapaViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Digite o numero do mapa")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Preencha a cor")]
        public string Cor { get; set; }

        public string UrlFoto { get; set; }
        public HttpPostedFile FileFoto { get; set; }

        [Required(ErrorMessage = "Selecione a letra")]
        [Display(Name ="Mapa")]
        public int IdLetra { get; set; }

        [Display(Name = "Local de saída")]
        public int? IdSaida { get; set; }

        [Required(ErrorMessage = "Selecione o territorio")]
        [Display(Name = "Território abrangente")]
        public int IdTerritorio { get; set; }

        public LetraViewModel Letra { get; set; }
        public SaidaViewModel Saida { get; set; }
        public TerritorioViewModel Territorio { get; set; }

        public List<SurdoViewModel> Surdos { get; set; }
    }
}