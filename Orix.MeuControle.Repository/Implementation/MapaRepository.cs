using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation.Base;
using System.Collections.Generic;
using System.Linq;

namespace Orix.MeuControle.Repository.Implementation
{
    public class MapaRepository : BaseRepository<MapaDomainModel>, Contracts.IMapaRepository
    {

        public new List<MapaDomainModel> Listar()
        {
            return base.Listar().OrderBy(x => x.ID).ToList();
        }
    }
}
