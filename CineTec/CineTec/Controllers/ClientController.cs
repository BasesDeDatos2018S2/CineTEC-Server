using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CineTec.Logic;
using CineTec.Models;

namespace CineTec.Controllers
{
    public class ClientController : ApiController
    {
        private Client_Logic client_ = new Client_Logic();

        // GET: api/Client
        [Route("api/Client")]
        [HttpGet]
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
        [Route("api/client/add")]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Client_Data data)
        {
            var result = client_.addClient(data);
            return Ok(result);
        }

        // POST: api/Client
        [Route("api/client/report")]
        [HttpPost]
        public IHttpActionResult Report([FromBody] Report_Data data)
        {
            Facturacion_Logic _Logic = new Facturacion_Logic();
            _Logic.CreateXml(data);
            return Ok();
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
