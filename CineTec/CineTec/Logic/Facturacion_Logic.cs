using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Xml;
using CineTec.Facturacion;
using CineTec.Models;
using Newtonsoft.Json;
using Npgsql;



namespace CineTec.Logic
{
    public class Facturacion_Logic
    {

        public Receptor GetReceptor(string idclient)
        {
            try
            {
                Client_Logic client_Logic = new Client_Logic();
                var clientJson = client_Logic.GetClient(idclient);
                Client_Data_Report client_Data_ = JsonConvert.DeserializeObject<Client_Data_Report>(clientJson.ToString());

                Receptor receptor = new Receptor(client_Data_.name, "01", client_Data_.identification,
                                                "2", "11", "01", "08", "", "506", Convert.ToInt32(client_Data_.phone),
                                                client_Data_.email);
                return receptor;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Emisor GetEmisor()
        {
            Emisor emisor = new Emisor("CineTec.SA", "02", "1234567890",
                                        "2", "11", "01", "01", "", "506",
                                        86866868, "ventas@cinetec.com");
            return emisor;
        }

        public HttpStatusCode CreateXml(Report_Data report_)
        {
            ConnectionPostgreSQL cn = new ConnectionPostgreSQL();
            NpgsqlConnection conection = cn.OpenConection();
            DataSet ds = new DataSet();
            //DataTable dt = new DataTable();
            //try /* Select After Validations*/
            //{
                using (conection)
                {
                    NpgsqlCommand cmd = new NpgsqlCommand
                    {
                        Connection = conection,
                        CommandText = "Select * from usp_screening_with_cinema("+report_.ID_Proyection.ToString()+","+report_.Butacas_Ocupadas.Count().ToString()+")",
                        CommandType = CommandType.Text
                    };
                    NpgsqlDataAdapter details = new NpgsqlDataAdapter(cmd);
                    details.Fill(ds);
                    Receptor receptor = GetReceptor(report_.ID_Cliente);
                    Emisor emisor = GetEmisor();
                    FacturaElectronicaCR factura = new FacturaElectronicaCR("50923191800310954724900100091010000000017120952430",
                                                                            "00900001090000000019", emisor, receptor, "01", "01", "01",
                                                                            ds, "01", 595);
                    //var xml = factura.CreaXMLFacturaElectronica();
                    //xml.Save(@"C:\Users\ggg\Escritorio\data.xml");
                    /*
                    using (var stream =  xml)
                    {
                        SmtpClient smtp = new SmtpClient
                        {
                            Port = 587,
                            UseDefaultCredentials = true,
                            Host = "smtp.gmail.com",
                            EnableSsl = true
                        };

                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("teconstruyecompany@gmail.com", "teconstruye");
                        var message = new System.Net.Mail.MailMessage("teconstruyecompany@gmail.com", receptor.CorreoElectronico, "Reporte Presupuesto", "Se adjunta el reporte de Presupuesto.");
                        message.Attachments.Add(new Attachment(stream, "factura.xml"));

                        smtp.Send(message);
                        */

                    SmtpClient smtp = new SmtpClient
                    {
                        Port = 587,
                        UseDefaultCredentials = true,
                        Host = "smtp.gmail.com",
                        EnableSsl = true
                    };

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("teconstruyecompany@gmail.com", "teconstruye");


      

                    var message = new System.Net.Mail.MailMessage("teconstruyecompany@gmail.com", "mau18alvarez@gmail.com", "Reporte Presupuesto", "Se adjunta el reporte de Presupuesto.");
                    //var stream = new MemoryStream();
                    //var reader = factura.CreaXMLFacturaElectronica();

                    var stream = new MemoryStream();

                   XmlDocument report = factura.CreaXMLFacturaElectronica();


                /*
                XmlElement root = report.CreateElement("testsuites");
                var items = report.GetElementsByTagName("testsuite");
                for (int i = 0; i < items.Count; i++)
                {
                   root.AppendChild(items[i]);
                }
                report.AppendChild(root);
                */
                /*using (var sw = new StringWriter())
               {
                   using (var xw = XmlWriter.Create(sw))
                   {
                       xw.WriteStartDocument();
                        xw.WriteStartElement("Factura");
                        xw.WriteElementString("test523", "a12");
                        xw.WriteEndElement();
                        xw.WriteEndDocument();
                        // Build Xml with xw.


                    }
                    System.Diagnostics.Debug.WriteLine(sw.ToString());
                }*/

                System.Diagnostics.Debug.WriteLine(Path.GetTempPath() + "factura.xml");
                report.Save(Path.GetTempPath() + "factura.xml");




            
                    message.Attachments.Add(new Attachment(Path.GetTempPath()+"factura.xml"));

                    smtp.Send(message);


                    return HttpStatusCode.OK;


                }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }
    }
}