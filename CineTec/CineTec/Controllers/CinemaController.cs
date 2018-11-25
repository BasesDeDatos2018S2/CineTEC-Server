using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CineTec.Logic;

namespace CineTec.Controllers
{
    public class CinemaController : ApiController
    {
        // GET: api/Cinema
        public IHttpActionResult Get()
        {
            Cinema_Logic cinema = new Cinema_Logic();
            var result = cinema.GetCinemas();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        // GET: api/Cinema/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cinema
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cinema/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cinema/5
        public void Delete(int id)
        {
        }
    }
}
