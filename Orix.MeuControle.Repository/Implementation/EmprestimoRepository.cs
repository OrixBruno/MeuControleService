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
                    .AsNoTracking()
                    .Include(x => x.Mapa)
                    .Include(x => x.Mapa.Letra)
                    .OrderBy(x => x.Mapa.Letra.Letra)
                    .ThenBy(x => x.Mapa.Numero)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public EmprestimoDomainModel CadastrarAtualizar(EmprestimoDomainModel emprestimoTela)
        {
            try
            {
                var emprestimoExistente = _table.FirstOrDefault(x => x.IDMapa == emprestimoTela.IDMapa);
                if (emprestimoExistente != null)
                {
                    if(emprestimoExistente.DataDevolucao == null)
                        ValidaDevolucao(emprestimoTela);
                    emprestimoExistente.DataDevolucao = null;
                    emprestimoExistente.DataEmprestimo = emprestimoTela.DataEmprestimo;
                    emprestimoExistente.Publicador = emprestimoTela.Publicador;
                    _conexao.Entry(emprestimoExistente).State = EntityState.Modified;
                    _conexao.SaveChanges();
                    return emprestimoExistente;
                }

                ValidaEmprestimo(emprestimoTela);
                var emprestimo = _table.Add(emprestimoTela);
                _conexao.SaveChanges();
                return emprestimo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        private void ValidaDevolucao(EmprestimoDomainModel emprestimoTela)
        {
            if (emprestimoTela.IDMapa < 1)
            {
                throw new Exception("Por favor selecione o mapa para devolução!");
            }
            if (emprestimoTela.DataDevolucao == null)
            {
                throw new Exception("Por favor selecione a data de devolução!");
            }
        }
        private void ValidaEmprestimo(EmprestimoDomainModel emprestimoTela)
        {
            if (emprestimoTela.IDMapa == null)
            {
                throw new Exception("Por favor selecione o mapa para empréstimo!");
            }
            if (emprestimoTela.DataEmprestimo == null)
            {
                throw new Exception("Por favor selecione a data de empréstimo!");
            }
            if (emprestimoTela.Publicador == null)
            {
                throw new Exception("Por favor insira o nome do publicador!");
            }
        }
        
    }
}
