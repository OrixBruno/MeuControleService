﻿using Orix.MeuControle.Domain.Mapa;
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
    public class EmprestimoController : ApiController
    {
        EmprestimoRepository _repository = new EmprestimoRepository();
        // GET: api/Emprestimo
        public List<EmprestimoDomainModel> Get()
        {
            return _repository.Listar();
        }

        // GET: api/Emprestimo/5
        public EmprestimoDomainModel Get(int id)
        {
            return _repository.Buscar(id);
        }

        // POST: api/Emprestimo
        public void Post(EmprestimoDomainModel emprestimo)
        {
            _repository.CadastrarAtualizar(emprestimo);
        }

        // PUT: api/Emprestimo/5
        public void Put(EmprestimoDomainModel emprestimo)
        {
            _repository.Editar(emprestimo);
        }

        // DELETE: api/Emprestimo/5
        public void Delete(int id)
        {
            _repository.Excluir(id);
        }
    }
}
