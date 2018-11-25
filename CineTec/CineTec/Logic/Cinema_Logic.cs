using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using CineTec.Models;

namespace CineTec.Logic
{
    public class Cinema_Logic
    {
        public List<Object> GetCinemas()
        {
            ConnectionPostgreSQL cn = new ConnectionPostgreSQL();
            NpgsqlConnection conection = cn.OpenConection();
            //DataTable dt = new DataTable();
            try /* Select After Validations*/
            {
                using (conection)
                {
                    List<Object> Cinema_List = new List<Object>();
                    NpgsqlCommand cmd = new NpgsqlCommand
                    {
                        Connection = conection,
                        CommandText = "Select * from movie_theater;",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    cmd.Dispose();

                    while (reader.Read())
                    {
                        Cinema_Data cinema_Data = new Cinema_Data();
                        cinema_Data.id = Convert.ToInt32(reader["id"]);
                        cinema_Data.Nombre = Convert.ToString(reader["name"]);
                        cinema_Data.Ubicacion = Convert.ToString(reader["ubication"]);
                        Cinema_List.Add(cinema_Data);

                    }
                    //da.Fill(dt);
                    conection.Close();

                    foreach (Cinema_Data m in Cinema_List)
                    {
                        List<Object> Room_List = new List<Object>();
                        conection.Open();
                        NpgsqlCommand cmd2 = new NpgsqlCommand
                        {
                            Connection = conection,
                            CommandText = "select* from usp_movie_room("+m.id+")",
                            CommandType = CommandType.Text
                        };
                        //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                        cmd2.Dispose();

                        while (reader2.Read())
                        {
                            Room_List.Add(Convert.ToInt32(reader2["id"]));
                        }
                        m.Salas = Room_List;
                        conection.Close();
                    }

                    return Cinema_List;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
