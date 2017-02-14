using Orix.MeuControle.Domain.Mapa;
using System.Collections.Generic;

namespace Orix.MeuControle.Repository.Contracts
{
    public interface ILetraRepository : Base.IGravacao<LetraDomainModel>, Base.ILeitura<LetraDomainModel>
    {
        new List<LetraDomainModel> Listar();
    }
}
