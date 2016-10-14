using Orix.MeuControle.Domain.Mapa;
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
    public class LetraController : ApiController
    {
        LetraRepository _repository = new LetraRepository();
        // GET: api/v1/Letra
        public List<LetraDomainModel> Get()
        {
            return _repository.Listar();
        }

        // GET: api/v1/Letra/5
        public LetraDomainModel Get(int id)
        {
            return _repository.Buscar(id);
        }

        // POST: api/v1/Letra
        public void Post(LetraDomainModel value)
        {
            _repository.Cadastrar(value);
        }

        // PUT: api/v1/Letra/5
        public void Put(LetraDomainModel value)
        {
            _repository.Editar(value);
        }

        // DELETE: api/v1/Letra/5
        public LetraDomainModel Delete(int id)
        {
            return _repository.Excluir(id);
        }
    }
}
