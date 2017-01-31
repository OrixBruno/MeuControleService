using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels
{
    public class EmprestimoViewModel
    {
        public int ID { get; set; }

        [Display(Name ="Numero do mapa")]
        [Required(ErrorMessage ="Por favor selecione o mapa.")]
        public int IDMapa { get; set; }
        public string Publicador { get; set; }

        [Display(Name ="Data de empréstimo")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Por favor selecione a data.")]
        public DateTime DataEmprestimo { get; set; }

        [Display(Name = "Data de devolução")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Por favor selecione a data.")]
        public DateTime? DataDevolucao { get; set; }

        public MapaViewModel Mapa { get; set; }
    }
}