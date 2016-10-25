using Orix.MeuControle.Domain;
using Orix.MeuControle.Repository.Implementation.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Orix.MeuControle.Repository.Implementation
{
    public class SurdoRepository : BaseRepository<SurdoDomainModel>, Contracts.ISurdoRepository
    {
        public new List<SurdoDomainModel> Listar()
        {
            try
            {
                return _table.Include(x => x.Mapa).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public new List<SurdoDomainModel> ListarPorTexto(String texto)
        {
            if (texto == null)
                return _table.Include(x => x.Mapa).OrderBy(x => x.Nome).ToList();

            return base._table.Include(x => x.Mapa).Where(x => x.Nome.Contains(texto.Trim())).OrderBy(x => x.Nome).ToList();
        }
        public new SurdoDomainModel Buscar(int id)
        {
            try
            {
                var surdo = _table
                    .Include(x => x.Mapa)
                    .Include(x => x.Mapa.Saida)
                    .Include(x => x.Mapa.Letra)
                    .Include(x => x.Mapa.Territorio)
                    .SingleOrDefault(x => x.ID == id);
                return surdo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		public int SurdosTotal(){

            return _table.Count();
		}
        public List<SurdoDomainModel> ListarOrdenado(String coluna, String texto)
        {
            IQueryable<SurdoDomainModel> tabelaFiltrada = _table;

            if (texto != null)
                tabelaFiltrada = _table.Include(x => x.Mapa).Where(x => x.Nome.Contains(texto.Trim()));

            if (coluna == "C")
                return tabelaFiltrada.OrderBy(x => x.Codigo).ToList();

            if (coluna == "N")
                return tabelaFiltrada.OrderBy(x => x.Nome).ToList();

            if (coluna == "I")
                return tabelaFiltrada.OrderBy(x => x.Idade).ToList();

            if (coluna == "R")
                return tabelaFiltrada.OrderBy(x => x.Rua).ToList();

            if (coluna == "M")
                return tabelaFiltrada.OrderBy(x => x.Numero).ToList();

            if (coluna == "B")
                return tabelaFiltrada.OrderBy(x => x.Bairro).ToList();

            if (coluna == "O")
                return tabelaFiltrada.OrderBy(x => x.Observacao).ToList();

            return tabelaFiltrada.ToList();
        }
    }
}
