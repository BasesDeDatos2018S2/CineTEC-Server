using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTec.Models
{
    public class Cinema_Data
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public List<Object> Salas { get; set; }
    }
}