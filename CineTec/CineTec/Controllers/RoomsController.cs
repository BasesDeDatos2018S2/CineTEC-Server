using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CineTec.Logic;

namespace CineTec.Controllers
{
    public class RoomsController : ApiController
    {
        private Rooms_Logic room = new Rooms_Logic();

        // GET: api/Rooms
        public IHttpActionResult Get()
        {
            
            var result = room.GetRooms();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }

        [Route("api/Rooms/butacas/{id}")]
        [HttpGet]
        public IHttpActionResult GetRooms(int id)
        {
            var result = this.room.GetButacasLlenas(id);
            return Ok(result);
        }

        // GET: api/Rooms/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Rooms
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Rooms/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Rooms/5
        public void Delete(int id)
        {
        }
    }
}
