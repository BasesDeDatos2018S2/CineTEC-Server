using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using CineTec.Models;

namespace CineTec.Logic
{
    public class Rooms_Logic
    {
        public List<Object> GetRooms()
        {
            ConnectionPostgreSQL cn = new ConnectionPostgreSQL();
            NpgsqlConnection conection = cn.OpenConection();
            //DataTable dt = new DataTable();
            try /* Select After Validations*/
            {
                using (conection)
                {
                    List<Object> Room_List = new List<Object>();
                    NpgsqlCommand cmd = new NpgsqlCommand
                    {
                        Connection = conection,
                        CommandText = "select* from movie_room;",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    cmd.Dispose();

                    while (reader.Read())
                    {
                        Rooms_Data rooms_Data = new Rooms_Data();
                        rooms_Data.ID = Convert.ToInt32(reader["id"]);
                        rooms_Data.Nombre = Convert.ToString(reader["name"]);
                        rooms_Data.Size = Convert.ToInt32(reader["capacity"]);
                        rooms_Data.Cine = Convert.ToInt32(reader["id_movie_theater"]);
                        Room_List.Add(rooms_Data);

                    }
                    //da.Fill(dt);
                    conection.Close();
                    return Room_List;

                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}