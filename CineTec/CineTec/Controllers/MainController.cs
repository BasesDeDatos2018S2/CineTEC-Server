using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Web.Http;
using CineTec.Logic;
using Npgsql;

namespace CineTec.Controllers
{
    public class Prueba
    {
        public int Id_actor { get; set; }
        public int Id_movie { get; set; }        
    }

    public class MainController : ApiController
    {
        // GET: api/Main
        public IHttpActionResult Get()
        {
            ConnectionPostgreSQL cn = new ConnectionPostgreSQL();
            NpgsqlConnection connection = cn.OpenConection();
            //DataTable dt = new DataTable();
            List<object> list = new List<object>();
            try /* Select After Validations*/
            {
                using (connection)
                {

                    NpgsqlCommand cmd = new NpgsqlCommand
                    {
                        Connection = connection,
                        CommandText = "Select * from Actors_Movie",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        Prueba prueba = new Prueba
                        {
                            Id_actor = Convert.ToInt32(reader["Id_actor"]),
                            Id_movie = Convert.ToInt32(reader["Id_movie"])
                        };
                        list.Add(prueba);

                    }
                    //da.Fill(dt);
                    cmd.Dispose();
                    connection.Close();
                }
            }
            catch (Exception ex) { }



            return Ok(list[1]);
        }

        // GET: api/Main/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Main
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Main/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Main/5
        public void Delete(int id)
        {
        }
    }
}
