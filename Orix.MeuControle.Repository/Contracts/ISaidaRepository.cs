using Orix.MeuControle.Domain.Mapa;
using System.Collections.Generic;

namespace Orix.MeuControle.Repository.Contracts
{
    public interface ISaidaRepository : Base.IGravacao<SaidaDomainModel>, Base.ILeitura<SaidaDomainModel>
    {
        new List<SaidaDomainModel> Listar();
    }
}
