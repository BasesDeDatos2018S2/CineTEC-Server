using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Npgsql;

namespace CineTec.Logic { 
    public class ConnectionPostgreSQL
    {

        public NpgsqlConnection OpenConection()
        {

            NpgsqlConnection connection = new NpgsqlConnection();
            var conectionString = "Server=cinetec.cg8mqwwu18oy.us-east-2.rds.amazonaws.com;Port=5432;User Id=tavo;Password=5uYypmvJqxCq5R22Dsqn;Database=CineTec";

            if (!string.IsNullOrWhiteSpace(conectionString))
            {

                try
                {
                    connection = new NpgsqlConnection(conectionString);
                    connection.Open();
                }
                catch (Exception)
                {
                    connection.Close();
                }

            }
            return connection;
        }
    }
}