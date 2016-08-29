using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Domain.Mapa
{
    public class FotoDomainModel
    {
        public Int32 ID { get; set; }
        public String URL { get; set; }
        public String Descricao { get; set; }

        public virtual MapaDomainModel Mapa { get; set; }
    }
}
