using Orix.MeuControle.Domain.Mapa;
using System.Collections.Generic;

namespace Orix.MeuControle.Repository.Contracts
{
    public interface IMapaRepository : Base.IGravacao<MapaDomainModel>, Base.ILeitura<MapaDomainModel>
    {
        new MapaDomainModel Excluir(int id);

        new void Cadastrar(MapaDomainModel mapa);

        new List<MapaDomainModel> Listar();

        IEnumerable<MapaDomainModel> ListarSelect();

        new MapaDomainModel Buscar(int id);
    }
}
