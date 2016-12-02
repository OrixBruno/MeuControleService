using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Orix.MeuControle.UI.Web.ViewModels
{
    public class SurdoViewModel
    {
        [Key]
        public Int32 ID { get; set; }

        [Required(ErrorMessage = "Digite o código do surdo")]
        public Int32 Codigo { get; set; }

        [Required(ErrorMessage = "Digite o nome")]
        [MaxLength(50, ErrorMessage = "Nome de no máximo 50 caracters")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Digite o genero")]
        [Display(Name = "Genêro")]
        public String Genero { get; set; }

        [Range(5, 150, ErrorMessage = "Idade permitida 5 á 150 anos")]
        public Int32 Idade { get; set; }

        [Required(ErrorMessage = "Rua obrigatório")]
        [MaxLength(50, ErrorMessage = "Rua de no máximo 50 caracters")]
        public String Rua { get; set; }

        [Required(ErrorMessage = "Numero da casa obrigatório")]
        [Range(0, 15000, ErrorMessage = "Numero permitido até 15000")]
        public Int32 Numero { get; set; }

        [Required(ErrorMessage = "Bairro obrigatório")]
        [MaxLength(50, ErrorMessage = "Bairro de no máximo 50 caracters")]
        public String Bairro { get; set; }

        [MaxLength(250, ErrorMessage = "Observacao com no máximo 250 caracters")]
        [Display(Name = "Observação")]
        public String Observacao { get; set; }
		
		public DateTime DataCadastro { get; set; }
        public DateTime DataModificacao { get; set; }

        [Display(Name ="Mapa")]
        public Int32? IdMapa { get; set; }
        public MapaViewModel Mapa { get; set; }
    }
}