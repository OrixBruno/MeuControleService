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

namespace Orix.MeuControle.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Authorize]
    public class SaidaController : ApiController
    {
        private readonly ISaidaRepository _repository;
        public SaidaController(ISaidaRepository repository)
        {
            _repository = repository;
        }
        // GET: api/v1/Saida
        public List<SaidaDomainModel> Get()
        {
            return _repository.Listar();
        }

        // GET: api/v1/Saida/5
        public SaidaDomainModel Get(int id)
        {
            return _repository.Buscar(id);
        }

        // POST: api/v1/Saida
        public SaidaDomainModel Post(SaidaDomainModel value)
        {
            return _repository.Cadastrar(value);
        }

        // PUT: api/v1/Saida/5
        public void Put(SaidaDomainModel value)
        {
            _repository.Editar(value);
        }

        // DELETE: api/v1/Saida/5
        public SaidaDomainModel Delete(int id)
        {
            return _repository.Excluir(id);
        }
    }
}
