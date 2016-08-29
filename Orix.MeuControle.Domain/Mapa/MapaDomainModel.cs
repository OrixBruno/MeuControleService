using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Domain.Mapa
{
    public class MapaDomainModel
    {
        public Int32 ID { get; set; }
        public Int32 Numero { get; set; }
        public String Cor { get; set; }
        public String UrlFoto { get; set; }

        public Int32 IdLetra { get; set; }
        public Int32 IdSaida { get; set; }
        public Int32 IdTerritorio { get; set; }

        public virtual LetraDomainModel Letra { get; set; }

        public virtual SaidaDomainModel Saida { get; set; }

        public virtual TerritorioDomainModel Territorio { get; set; }

        public virtual FotoDomainModel Foto { get; set; }
    }
}
