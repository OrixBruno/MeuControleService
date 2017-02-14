using Orix.MeuControle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Repository.Contracts
{
    public interface IAutenticacaoRepository : Base.ILeitura<ContaDomainModel>
    {
        bool Login(ContaDomainModel conta);
    }
}
