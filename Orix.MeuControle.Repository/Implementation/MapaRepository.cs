using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation.Base;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace Orix.MeuControle.Repository.Implementation
{
    public class MapaRepository : BaseRepository<MapaDomainModel>, Contracts.IMapaRepository
    {

        public new List<MapaDomainModel> Listar()
        {
            try
            {
                return _table
                    .Include(x => x.Letra)
                    .Include(x => x.Territorio)
                    .Include(x => x.Saida)
                    .OrderBy(x => x.ID).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public new MapaDomainModel Buscar(int id)
        {
            try
            {
                return _table
                    .Include(x => x.Letra)
                    .Include(x => x.Territorio)
                    .Include(x => x.Saida)
                    .FirstOrDefault(x => x.ID == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
