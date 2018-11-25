using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CineTec.Logic;

namespace CineTec.Controllers
{
    public class MovieController : ApiController
    {
        // GET: api/Movie
        [Route("api/Movie")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Movie_Logic movie = new Movie_Logic();
            List<Object> result = movie.Movies();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
            
        }

        // GET: api/Movie/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Movie
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Movie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Movie/5
        public void Delete(int id)
        {
        }
    }
}
