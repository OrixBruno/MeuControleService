using Orix.MeuControle.Domain.Mapa;
using System.Collections.Generic;

namespace Orix.MeuControle.Repository.Contracts
{
    public interface ITerritorioRepository : Base.IGravacao<TerritorioDomainModel>, Base.ILeitura<TerritorioDomainModel>
    {
        new List<TerritorioDomainModel> Listar();
    }
}
