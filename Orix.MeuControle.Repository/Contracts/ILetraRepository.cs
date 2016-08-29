using Orix.MeuControle.Domain.Mapa;

namespace Orix.MeuControle.Repository.Contracts
{
    interface ILetraRepository : Base.IGravacao<LetraDomainModel>, Base.ILeitura<LetraDomainModel>
    {
    }
}
