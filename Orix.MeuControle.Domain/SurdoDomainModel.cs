using Orix.MeuControle.Domain.Mapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Domain
{
    public class SurdoDomainModel
    {
        public Int32 Codigo { get; set; }
        public String Nome { get; set; }
        public String Genero { get; set; }
        public Int32 Idade { get; set; }
        public String Rua { get; set; }
        public Int32 Numero { get; set; }
        public String Bairro { get; set; }
        public String Observacao { get; set; }

        public Int32 ID_Mapa { get; set; }
        public virtual MapaDomainModel MapaDomainModel { get; set; }
    }
}
