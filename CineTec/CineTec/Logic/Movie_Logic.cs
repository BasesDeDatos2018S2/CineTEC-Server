using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using CineTec.Models;

namespace CineTec.Logic
{
    public class Movie_Logic
    {
        public List<Object> Movies()
        {

            ConnectionPostgreSQL cn = new ConnectionPostgreSQL();
            NpgsqlConnection conection = cn.OpenConection();
            //DataTable dt = new DataTable();
            try /* Select After Validations*/
            {
                using (conection)
                {
                    List<Object> Movie_List = new List<Object>();
                    NpgsqlCommand cmd = new NpgsqlCommand
                    {
                        Connection = conection,
                        CommandText = "Select * from usp_movie();",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    cmd.Dispose();
                
                    while (reader.Read())
                    {
                        Movie_Data movie_Data = new Movie_Data();
                        movie_Data.ID_ = Convert.ToInt32(reader["Id"]);
                        movie_Data.Nombre_Original_ = Convert.ToString(reader["Original_name"]);
                        movie_Data.Nombre_ = Convert.ToString(reader["Traduced_name"]);
                        movie_Data.Estado_ = Convert.ToBoolean(reader["Billboard_status"]);
                        movie_Data.Duracion_ = Convert.ToInt32(reader["Duration"]);
                        movie_Data.Director_ = Convert.ToString(reader["Director"]);
                        movie_Data.Clasificacion_ = Convert.ToString(reader["Clasification"]);
                        movie_Data.Imagen_ = Convert.ToString(reader["Image"]);
                        Movie_List.Add(movie_Data);

                    }
                    //da.Fill(dt);
                    conection.Close();
                    
                    foreach (Movie_Data m in Movie_List)
                    {
                        List<Object> ProtagonistasList = new List<Object>();
                        conection.Open();
                        NpgsqlCommand cmd2 = new NpgsqlCommand
                        {
                            Connection = conection,
                            CommandText = "Select* from usp_actors_movie("+m.ID_+")",
                            CommandType = CommandType.Text
                        };
                        //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                        cmd2.Dispose();

                        while (reader2.Read())
                        {
                            Actors_Data actors_Data = new Actors_Data();
                            actors_Data.ID_ = Convert.ToInt32(reader2["Id"]);
                            actors_Data.Name_ = Convert.ToString(reader2["Name"]);
                            actors_Data.LastName = Convert.ToString(reader2["Lastname"]);
                            ProtagonistasList.Add(actors_Data);
                        }
                        m.Protagonistas_ = ProtagonistasList;
                        conection.Close();
                    }
                    
                    return Movie_List;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}