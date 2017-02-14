using Orix.MeuControle.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Orix.MeuControle.Repository.Implementation.Base
{
    public class BaseRepository<TEntity> where TEntity : class, new()
    {
        protected DbSet<TEntity> _table;
        protected Conexao _conexao;
        public BaseRepository()
        {
            _conexao = new Conexao();
            _table = _conexao.Set<TEntity>();
        }
        private void SaveChanges()
        {
            _conexao.SaveChanges();
        }

        public TEntity Buscar(Int32 id)
        {
            try
            {
                return _table.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TEntity Cadastrar(TEntity dadosTela)
        {
            var table = _table.Add(dadosTela);
            TratamentoExcecao(() =>
            {
                SaveChanges();
            });

            return table;
        }
        public List<TEntity> CadastrarLista(List<TEntity> listaDados)
        {
            List<TEntity> table = new List<TEntity>();
            foreach (var item in listaDados)
            {
                table.Add(
                    _table.Add(item));
                TratamentoExcecao(() =>
                {
                    SaveChanges();
                });
            }

            return table;
        }
        public void Editar(TEntity dadosTela)
        {
            _conexao.Entry(dadosTela).State = EntityState.Modified;

            TratamentoExcecao(() =>
            {
                SaveChanges();
            });
        }

        public TEntity Excluir(Int32 id)
        {
            var table = _table.Remove(_table.Find(id));
            SaveChanges();
            return table;
        }

        public List<TEntity> Listar()
        {
            try
            {
                return _table.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TEntity> ListarPorTexto(String texto)
        {
            return _table.ToList();
        }

        protected void TratamentoExcecao(Action acao)
        {
            try
            {
                acao();
            }
            catch (Exception ex)
            {
                if (ex.InnerException.InnerException.Message.Contains("Cannot insert duplicate key row in object"))
                    throw new Exception("Não é permitido inserir itens duplicados!");

                if (ex.InnerException.InnerException.Message.Contains("A instrução INSERT conflitou com a restrição do FOREIGN KEY"))
                    throw new Exception("Problemas com a chave estrangeira. Verifique se adicionou os valores corretamentes!");

                if (ex.InnerException.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
                    throw new Exception("Não é possivel excluir itens utilizados em cadastros. Verifique o item a ser excluído!");

                throw new Exception(ex.Message);
            }
        }
        
    }
}
