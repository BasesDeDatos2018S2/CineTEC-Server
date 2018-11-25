using CineTec.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CineTec.Logic
{
    public class Actors_Logic
    {
        public List<Object> GetListActors()
        {
            ConnectionPostgreSQL cn = new ConnectionPostgreSQL();
            NpgsqlConnection conection = cn.OpenConection();
            //DataTable dt = new DataTable();
            try /* Select After Validations*/
            {
                using (conection)
                {
                    List<Object> ProtagonistasList = new List<Object>();
                    NpgsqlCommand cmd = new NpgsqlCommand
                    {
                        Connection = conection,
                        CommandText = "select* from actors;",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    cmd.Dispose();

                    while (reader.Read())
                    {
                        Actors_Data actors_Data = new Actors_Data();
                        actors_Data.id = Convert.ToInt32(reader["Id"]);
                        actors_Data.Name = Convert.ToString(reader["Name"]);
                        actors_Data.LastName = Convert.ToString(reader["Lastname"]);
                        ProtagonistasList.Add(actors_Data);
                    }
                    conection.Close();
                    return ProtagonistasList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}