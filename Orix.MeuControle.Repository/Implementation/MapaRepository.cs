using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation.Base;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace Orix.MeuControle.Repository.Implementation
{
    public class MapaRepository : BaseRepository<MapaDomainModel>, Contracts.IMapaRepository
    {
        public new MapaDomainModel Excluir(int id)
        {
            try
            {
                if (_conexao.Emprestimo.Any(x => x.IDMapa == id))                
                    throw new Exception("Existe empréstimo cadastrado com este mapa. Por favor excluia o empréstimo!");

                var mapaRemovido = _table.Remove(_table.Find(id));
                _conexao.SaveChanges();
                return mapaRemovido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new void Cadastrar(MapaDomainModel mapa)
        {
            try
            {
                if (_table.Any(x => x.IdLetra == mapa.IdLetra && x.Numero == mapa.Numero))
                    throw new Exception("Mapa já cadastrado!");

                _table.Add(mapa);
                _conexao.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public new List<MapaDomainModel> Listar()
        {
            try
            {
                return _table
                    .AsNoTracking()
                    .Include(x => x.Letra)
                    .Include(x => x.Territorio)
                    .Include(x => x.Saida)
                    .OrderBy(x => x.Letra.Letra)
                    .ThenBy(x => x.Numero)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public IEnumerable<MapaDomainModel> ListarSelect()
        {
            try
            {
                return _table
                    .Include(x => x.Letra)
                    .Include(x => x.Territorio)
                    .Include(x => x.Saida)
                    .OrderBy(x => x.Numero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public new MapaDomainModel Buscar(int id)
        {
            try
            {
                return _table
                    .Include(x => x.Letra)
                    .Include(x => x.Territorio)
                    .Include(x => x.Saida)
                    .FirstOrDefault(x => x.ID == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
