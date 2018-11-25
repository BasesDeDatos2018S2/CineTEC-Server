using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CineTec.Logic;

namespace CineTec.Controllers
{
    public class ClientController : ApiController
    {
        private Client_Logic client_ = new Client_Logic();

        // GET: api/Client
        public IHttpActionResult Get()
        {
            var result = client_.GetClients();
           
            return Ok(result);
        }

        // GET: api/Client/5
        [Route("api/Client/{ssn}")]
        [HttpGet]
        public IHttpActionResult Get(string ssn)
        {
            var result = client_.GetClient(ssn);
            return Ok(result);
        }

        // POST: api/Client
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
