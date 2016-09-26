﻿using Orix.MeuControle.Domain.Mapa;
using Orix.MeuControle.Repository.Implementation;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Orix.MeuControle.Service.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TerritorioController : ApiController
    {
        TerritorioRepository _repository = new TerritorioRepository();
        // GET: api/v1/Territorio
        public List<TerritorioDomainModel> Get()
        {
            return _repository.Listar();
        }

        // GET: api/v1/Territorio/5
        public TerritorioDomainModel Get(int id)
        {
            return _repository.Buscar(id);
        }

        // POST: api/v1/Territorio
        public TerritorioDomainModel Post(TerritorioDomainModel territorioNovo)
        {
            return _repository.Cadastrar(territorioNovo);
        }

        // PUT: api/v1/Territorio
        public void Put(TerritorioDomainModel territorioAtualizar)
        {
            _repository.Editar(territorioAtualizar);
        }

        // DELETE: api/v1/Territorio/5
        public TerritorioDomainModel Delete(int id)
        {
            return _repository.Excluir(id);
        }
    }
}
