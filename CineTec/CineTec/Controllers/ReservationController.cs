using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CineTec.Models;

namespace CineTec.Controllers
{
    public class ReservationController : ApiController
    {
        // GET: api/Reservation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Reservation/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reservation
        public IHttpActionResult Post([FromBody] Compra_Butaca_Data data)
        {

        }

        // PUT: api/Reservation/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reservation/5
        public void Delete(int id)
        {
        }
    }
}
