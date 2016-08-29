using System.Collections.Generic;
using Orix.MeuControle.Domain.Mapa;
using System.Linq;
using Orix.MeuControle.Repository.Implementation.Base;

namespace Orix.MeuControle.Repository.Implementation
{
    public class TerritorioRepository : BaseRepository<TerritorioDomainModel>, Contracts.ITerritorioRepository
    {

        public new List<TerritorioDomainModel> Listar()
        {
            return base.Listar().OrderBy(x => x.Nome).ToList();
        }
    }
}
