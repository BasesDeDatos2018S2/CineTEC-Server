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

        private Cinema_Logic cinema = new Cinema_Logic();

        // GET: api/Cinema
        public IHttpActionResult Get()
        {
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

        [Route("api/Screening/Available/{id}")]
        [HttpGet]
        public IHttpActionResult GetAvailableScreening(int id)
        {
            var result = this.cinema.GetListMoviesProyect(id);
            return Ok(result);
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
