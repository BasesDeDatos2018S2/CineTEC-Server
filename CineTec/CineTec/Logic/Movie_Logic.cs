using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
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
                        movie_Data.id = Convert.ToInt32(reader["Id"]);
                        movie_Data.Nombre_Original = Convert.ToString(reader["Original_name"]);
                        movie_Data.Nombre = Convert.ToString(reader["Traduced_name"]);
                        movie_Data.Estado = Convert.ToBoolean(reader["Billboard_status"]);
                        movie_Data.Duracion = Convert.ToInt32(reader["Duration"]);
                        movie_Data.Director = Convert.ToString(reader["Director"]);
                        movie_Data.Clasificacion = Convert.ToString(reader["Clasification"]);
                        movie_Data.Imagen = Convert.ToString(reader["Image"]);
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
                            CommandText = "Select* from usp_actors_movie("+m.id+")",
                            CommandType = CommandType.Text
                        };
                        //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                        cmd2.Dispose();

                        while (reader2.Read())
                        {
                            Actors_Data actors_Data = new Actors_Data();
                            actors_Data.id = Convert.ToInt32(reader2["Id"]);
                            actors_Data.Name = Convert.ToString(reader2["Name"]);
                            actors_Data.LastName = Convert.ToString(reader2["Lastname"]);
                            ProtagonistasList.Add(actors_Data);
                        }
                        m.Protagonistas = ProtagonistasList;
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

        public void addMovie(Movie_Data data)
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
                        CommandText = "Insert into movies values(" + data.id + ", " + data.Estado + "," + data.Nombre_Original + ", " + data.Nombre + "," + data.Duracion + "," + data.Director + "," + data.Clasificacion + "," + data.Imagen + ")",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}