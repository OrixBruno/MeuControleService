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
        [Display(Name ="Numero Mapa")]
        public int? IDMapa { get; set; }
        public String Publicador { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public MapaViewModel Mapa { get; set; }
    }
}