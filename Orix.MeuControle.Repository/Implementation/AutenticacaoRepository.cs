using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orix.MeuControle.Domain;

namespace Orix.MeuControle.Repository.Implementation
{
    public class AutenticacaoRepository : Base.BaseRepository<ContaDomainModel>, Contracts.IAutenticacaoRepository
    {
        public bool Login(ContaDomainModel conta)
        {
            var usuarioConta = _table.FirstOrDefault(x => x.Usuario == conta.Usuario);
            if (usuarioConta == null)
                return false;

            if (usuarioConta.Senha == conta.Senha)
                return true;

            return false;
        }
    }
}
