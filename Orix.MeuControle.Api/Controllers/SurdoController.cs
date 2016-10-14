using Orix.MeuControle.Domain;
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
    public class SurdoController : ApiController
    {
        SurdoRepository _repository = new SurdoRepository();
        // GET: api/Surdo
        public List<SurdoDomainModel> Get()
        {
            return _repository.Listar();
        }
        // GET: api/v1/Surdo?nome=        
        public List<SurdoDomainModel> Get(String nome)
        {
            return _repository.ListarPorTexto(nome);
        }
        // GET: api/Surdo/5
        public SurdoDomainModel Get(int id)
        {
            return _repository.Buscar(id);
        }

        // POST: api/Surdo
        public void Post(SurdoDomainModel dadoTela)
        {
            _repository.Cadastrar(dadoTela);
        }

        // PUT: api/Surdo
        public void Put(SurdoDomainModel dadoTela)
        {
            _repository.Editar(dadoTela);
        }

        // DELETE: api/Surdo/5
        public SurdoDomainModel Delete(int id)
        {
            return _repository.Excluir(id);
        }
    }
}
