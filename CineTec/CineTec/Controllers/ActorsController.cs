using CineTec.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CineTec.Controllers
{
    public class ActorsController : ApiController
    {
        private Actors_Logic actors_Logic = new Actors_Logic();
        // GET: api/Actors
        public IHttpActionResult Get()
        {
            var result = this.actors_Logic.GetListActors();
            return Ok(result);
        }

        // GET: api/Actors/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Actors
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Actors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Actors/5
        public void Delete(int id)
        {
        }
    }
}
