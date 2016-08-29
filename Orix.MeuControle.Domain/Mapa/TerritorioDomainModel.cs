using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Domain.Mapa
{
    public class TerritorioDomainModel
    {
        public Int32 ID { get; set; }

        public String Nome { get; set; }

        public virtual ICollection<MapaDomainModel> ListaMapa { get; set; }
    }
}
