using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Orix.MeuControle.Repository.Implementation
{
    public class EmprestimoRepository : Base.BaseRepository<EmprestimoDomainModel>, IEmprestimoRepository
    {
        public new List<EmprestimoDomainModel> Listar()
        {
            try
            {
                return _table
                    .Include(x => x.Mapa)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
