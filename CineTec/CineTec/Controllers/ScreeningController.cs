using CineTec.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CineTec.Controllers
{
    public class ScreeningController : ApiController
    {
        private Screening_Logic screening_Logic = new Screening_Logic();
        // GET: api/Screening
        public IHttpActionResult Get()
        {
            var result = this.screening_Logic.GetListScreening();
            return Ok(result);
        }

        // GET: api/Screening/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Screening
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Screening/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Screening/5
        public void Delete(int id)
        {
        }
    }
}
