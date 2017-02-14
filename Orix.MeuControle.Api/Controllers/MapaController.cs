using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Contracts;
using Orix.MeuControle.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Orix.MeuControle.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[Authorize]
    public class MapaController : ApiController
    {
        private readonly IMapaRepository _repository;
        public MapaController(IMapaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/v1/Mapa/GetSelect
        public List<ViewModel> GetSelect()
        {         
            return _repository.ListarSelect().Select(x => new ViewModel
            {
                Letra = x.Letra.Letra,
                Local = x.Territorio.Nome,
                Numero = x.Numero
            }).ToList();

        }
        public class ViewModel
        {
            public string Letra { get; set; }
            public int Numero { get; set; }
            public string Local { get; set; }
        }

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
        public MapaDomainModel Delete(int id)
        {
            return _repository.Excluir(id);
        }        
    }
}
