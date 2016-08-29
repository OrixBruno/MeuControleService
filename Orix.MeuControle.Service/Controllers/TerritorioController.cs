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
    public class TerritorioController : ApiController
    {
        TerritorioRepository _repository = new TerritorioRepository();
        // GET: api/v1/Territorio
        public List<TerritorioDomainModel> Get()
        {
            return _repository.Listar();
        }

        // GET: api/v1/Territorio/5
        public string Get(int id)
        {
            try
            {
                return "XD";
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: api/v1/Territorio
        public void Post([FromBody]string value)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/v1/Territorio/5
        public void Put(int id, [FromBody]string value)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/v1/Territorio/5
        public void Delete(int id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
