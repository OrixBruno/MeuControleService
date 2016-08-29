using System.Collections.Generic;
using Orix.MeuControle.Domain.Mapa;
using System.Linq;
using Orix.MeuControle.Repository.Implementation.Base;

namespace Orix.MeuControle.Repository.Implementation
{
    public class LetraRepository : BaseRepository<LetraDomainModel>, Contracts.ILetraRepository
    {
        public new List<LetraDomainModel> Listar()
        {
            return base.Listar().OrderBy(x => x.Letra).ToList();
        }
    }
}
