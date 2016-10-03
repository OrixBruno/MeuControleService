using Orix.MeuControle.Domain;
using Orix.MeuControle.Repository.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Repository.Implementation
{
    public class SurdoRepository : BaseRepository<SurdoDomainModel>, Contracts.ISurdoRepository
    {
        public new List<SurdoDomainModel> ListarPorTexto(String texto)
        {
            return base._table.Where(x=>x.Nome.Contains(texto)).ToList();
        }
    }
}
