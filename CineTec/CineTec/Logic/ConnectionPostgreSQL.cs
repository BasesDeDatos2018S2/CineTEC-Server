using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;

namespace CineTec.Logic { 
    public class ConnectionPostgreSQL
    {

        public NpgsqlConnection OpenConection()
        {

            NpgsqlConnection conection = new NpgsqlConnection();
            //"Data Source=cinetec.cg8mqwwu18oy.us-east-2.rds.amazonaws.com;Initial Catalog=CineTec;User ID=tavo;Password=5uYypmvJqxCq5R22Dsqn;";
            //"Server=cinetec.cg8mqwwu18oy.us-east-2.rds.amazonaws.com;Port=5432;User Id=tavo;Password=5uYypmvJqxCq5R22Dsqn;Database=CineTec;";
            string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CineTec"].ConnectionString;
            if (!string.IsNullOrWhiteSpace(conectionString))
            {

                try
                {
                    conection = new NpgsqlConnection(conectionString);
                    conection.Open();
                }
                catch (Exception)
                {
                    conection.Close();
                }

            }
            return conection;
        }
    }
}