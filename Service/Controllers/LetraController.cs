using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LetraController : ApiController
    {
        LetraRepository _repository = new LetraRepository();
        // GET: api/v1/Letra
        public IEnumerable<LetraDomainModel> Get()
        {
            return _repository.Listar();
        }

        // GET: api/v1/Letra/5
        public LetraDomainModel Get(int id)
        {
            return _repository.Buscar(id);
        }

        // POST: api/v1/Letra
        public void Post([FromBody]LetraDomainModel value)
        {
            _repository.Cadastrar(value);
        }

        // PUT: api/v1/Letra/5
        public void Put([FromBody]LetraDomainModel value)
        {
            _repository.Editar(value);
        }

        // DELETE: api/v1/Letra/5
        public void Delete(int id)
        {
            _repository.Excluir(id);
        }
    }
}
