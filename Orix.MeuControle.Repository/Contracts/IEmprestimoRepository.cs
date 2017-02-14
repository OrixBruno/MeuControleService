using Orix.MeuControle.Domain.Mapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Repository.Contracts
{
    public interface IEmprestimoRepository : Base.IGravacao<EmprestimoDomainModel>, Base.ILeitura<EmprestimoDomainModel>
    {
        new List<EmprestimoDomainModel> Listar();

        EmprestimoDomainModel CadastrarAtualizar(EmprestimoDomainModel emprestimoTela);
    }
}
