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
            var conectionString = "Server=192.168.100.12;Port=5432;User Id=postgres;Password=1517;Database=CineTec;";

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