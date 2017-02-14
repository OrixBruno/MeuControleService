using Orix.MeuControle.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.Repository.Contracts
{
    public interface ISurdoRepository : Base.IGravacao<SurdoDomainModel>, Base.ILeitura<SurdoDomainModel>
    {
        new List<SurdoDomainModel> Listar();

        List<SurdoDomainModel> ListarPorTexto(string texto);

        new SurdoDomainModel Buscar(int id);

        int SurdosTotal();

        List<SurdoDomainModel> ListarOrdenado(string coluna, string texto);
    }
}
