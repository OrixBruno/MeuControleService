using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Domain.Mapa
{
    public class EmprestimoDomainModel
    {
        public int ID { get; set; }
        public int? IDMapa { get; set; }
        public String Publicador { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public MapaDomainModel Mapa { get; set; }
    }
}
