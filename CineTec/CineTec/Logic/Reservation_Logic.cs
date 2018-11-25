using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using CineTec.Models;
using Npgsql;

namespace CineTec.Logic
{
    public class Reservation_Logic
    {
        public HttpStatusCode CreateReservation(Par_Butaca par_Butaca)
        {
            ConnectionPostgreSQL cn = new ConnectionPostgreSQL();
            NpgsqlConnection conection = cn.OpenConection();
            //DataTable dt = new DataTable();
            try /* Select After Validations*/
            {
                using (conection)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                    {
                        Connection = conection,
                        CommandText = "select* from actors;",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    cmd.Dispose();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conection.Close();
                    return HttpStatusCode.OK;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}