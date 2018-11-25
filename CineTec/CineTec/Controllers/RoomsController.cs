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
        // GET: api/Rooms
        public IHttpActionResult Get()
        {
            Rooms_Logic room = new Rooms_Logic();
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
