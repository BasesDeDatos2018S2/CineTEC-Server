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
        public HttpStatusCode CreateReservation(Compra_Butaca_Data compra_Butaca_Data)
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
                        CommandText = "select* from usp_billcreator2(" + compra_Butaca_Data.butacas.Count().ToString()+","+compra_Butaca_Data.client.ToString()+","+compra_Butaca_Data.screening.ToString()+")",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conection.Close();

                    conection.Open();
                    NpgsqlCommand cmd2 = new NpgsqlCommand
                    {
                        Connection = conection,
                        CommandText = "Select* from usp_billcreator3()",
                        CommandType = CommandType.Text
                    };
                    //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    NpgsqlDataReader reader2 = cmd2.ExecuteReader();
                    cmd2.Dispose();

                    reader2.Read();
                    int id_bill = Convert.ToInt32(reader2["Id_bill"]);
                    
                    conection.Close();

                    /////////
                    ///
                    foreach (Par_Butaca p in compra_Butaca_Data.butacas)
                    {
                        conection.Open();
                        NpgsqlCommand cmd3 = new NpgsqlCommand
                        {
                            Connection = conection,
                            CommandText = "select* from usp_seat1("+p.row+","+p.col+","+compra_Butaca_Data.screening+","+id_bill+")",
                            CommandType = CommandType.Text
                        };
                        //NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        cmd3.ExecuteNonQuery();
                        cmd3.Dispose();
                        conection.Close();
                    }

                    return HttpStatusCode.OK;
                }
            }
            catch (Exception e)
            {
                return HttpStatusCode.Accepted;
            }
        }
    }
}