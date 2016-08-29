using Orix.MeuControle.Domain.Mapa;

namespace Orix.MeuControle.Repository.Contracts
{
    interface ITerritorioRepository : Base.IGravacao<TerritorioDomainModel>, Base.ILeitura<TerritorioDomainModel>
    {
    }
}
