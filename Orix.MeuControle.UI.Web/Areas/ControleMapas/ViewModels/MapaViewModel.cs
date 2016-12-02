using Orix.MeuControle.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels
{
    public class MapaViewModel
    {
        public Int32 ID { get; set; }

        [Required(ErrorMessage ="Digite o numero do mapa")]
        public Int32 Numero { get; set; }

        [Required(ErrorMessage = "Preencha a cor")]
        public String Cor { get; set; }
        public String UrlFoto { get; set; }
        public HttpPostedFile FileFoto { get; set; }

        [Required(ErrorMessage = "Selecione a letra")]
        [Display(Name ="Mapa")]
        public Int32 IdLetra { get; set; }

        public Int32? IdSaida { get; set; }

        [Required(ErrorMessage = "Selecione o territorio")]
        public Int32 IdTerritorio { get; set; }

        public LetraViewModel Letra { get; set; }
        public SaidaViewModel Saida { get; set; }
        public TerritorioViewModel Territorio { get; set; }

        public List<SurdoViewModel> Surdos { get; set; }
    }
}