using CineTec.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CineTec.Logic
{
    public class Screening_Logic
    {
        public List<Object> GetListScreening()
        {
            ConnectionPostgreSQL cn = new ConnectionPostgreSQL();
            NpgsqlConnection conection = cn.OpenConection();
            //DataTable dt = new DataTable();
            try /* Select After Validations*/
            {
                using (conection)
                {
                    List<Object> ScreeningList = new List<Object>();
                    NpgsqlCommand cmd = new NpgsqlCommand
                    {
                        Connection = conection,
                        CommandText = "select* from projection;",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    cmd.Dispose();

                    while (reader.Read())
                    {
                        Screening_Data screening_data = new Screening_Data();
                        screening_data.id = Convert.ToInt32(reader["id"]);
                        screening_data.hour = Convert.ToString(reader["hour"]);
                        screening_data.id_movie = Convert.ToInt32(reader["id_movie"]);
                        screening_data.id_movie_room = Convert.ToInt32(reader["id_movie_room"]);
                        screening_data.price = Convert.ToInt32(reader["price"]);
                        screening_data.date = Convert.ToString(reader["date"]);
                        ScreeningList.Add(screening_data);
                    }
                    conection.Close();

                    foreach (Screening_Data m in ScreeningList)
                    {
                        List<Object> butacasList = new List<Object>();
                        conection.Open();
                        NpgsqlCommand cmd2 = new NpgsqlCommand
                        {
                            Connection = conection,
                            CommandText = "Select* from usp_seats_projection(" + m.id + ")",
                            CommandType = CommandType.Text
                        };
                        //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                        cmd2.Dispose();

                        while (reader2.Read())
                        {
                            Butaca_Data butaca_Data = new Butaca_Data();
                            butaca_Data.seats_id = Convert.ToInt32(reader2["seats_id"]);
                            butaca_Data.seat_column = Convert.ToInt32(reader2["seat_column"]);
                            butaca_Data.seat_row = Convert.ToInt32(reader2["seat_row"]);
                            butacasList.Add(butaca_Data);
                        }
                        m.Butacas_ocupadas = butacasList;
                        conection.Close();
                    }

                    return ScreeningList;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}