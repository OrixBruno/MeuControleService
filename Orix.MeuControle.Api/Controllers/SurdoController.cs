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
    public class SurdoController : ApiController
    {
        SurdoRepository _repository = new SurdoRepository();
        // GET: api/Surdo
        public List<SurdoDomainModel> Get()
        {
            return _repository.Listar();
        }
        [HttpGet]
        public int SurdosTotal()
        {
            return _repository.SurdosTotal();
        }
        [HttpGet]
        public List<SurdoDomainModel> ListaOrdenada(String coluna, String texto)
        {
            return _repository.ListarOrdenado(coluna, texto);
        }
        // GET: api/v1/Surdo/Get?nome=        
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
            dadoTela.DataCadastro = DateTime.Now;
            dadoTela.DataModificacao = DateTime.Now;
            _repository.Cadastrar(dadoTela);
        }
        [HttpPost]
        public void PostLista(List<SurdoDomainModel> listaSurdo)
        {
            foreach (var item in listaSurdo)
            {
                item.DataCadastro = DateTime.Now;
                item.DataModificacao = DateTime.Now;
            }
            _repository.CadastrarLista(listaSurdo);
        }
        // PUT: api/Surdo
        public void Put(SurdoDomainModel dadoTela)
        {
            dadoTela.DataModificacao = DateTime.Now;
            _repository.Editar(dadoTela);
        }

        // DELETE: api/Surdo/5
        public SurdoDomainModel Delete(int id)
        {
            return _repository.Excluir(id);
        }
    }
}
