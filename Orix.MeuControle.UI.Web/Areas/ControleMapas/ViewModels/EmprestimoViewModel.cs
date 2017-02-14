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
        [Required(ErrorMessage = "Por favor selecione a data.")]
        public DateTime DataEmprestimo { get; set; }

        [Display(Name = "Data de devolução")]
        [Required(ErrorMessage = "Por favor selecione a data.")]
        public DateTime? DataDevolucao { get; set; }

        public MapaViewModel Mapa { get; set; }
    }
}