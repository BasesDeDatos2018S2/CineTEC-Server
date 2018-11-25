using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTec.Models
{
    public class Cinema_Data
    {
        public int ID_ { get; set; }
        public string Nombre_ { get; set; }
        public string Ubicacion_ { get; set; }
        public List<Object> Salas_ { get; set; }
    }
}