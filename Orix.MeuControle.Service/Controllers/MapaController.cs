using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Orix.MeuControle.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MapaController : ApiController
    {
        MapaRepository _repository = new MapaRepository();
        // GET: api/v1/Mapa
        public IEnumerable<MapaDomainModel> Get()
        {
            return _repository.Listar();
        }

        // GET: api/v1/Mapa/5
        public MapaDomainModel Get(int id)
        {
            return _repository.Buscar(id);
        }

        // POST: api/v1/Mapa
        public void Post(MapaDomainModel value)
        {
            _repository.Cadastrar(value);
        }

        // PUT: api/v1/Mapa/5
        public void Put(MapaDomainModel value)
        {
            _repository.Editar(value);
        }

        // DELETE: api/v1/Mapa/5
        public void Delete(int id)
        {
            _repository.Excluir(id);
        }
    }
}
