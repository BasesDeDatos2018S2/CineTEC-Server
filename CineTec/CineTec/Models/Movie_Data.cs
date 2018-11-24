using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTec.Models
{
    public class Movie_Data
    {
        public int ID_ { get; set; }
        public string Nombre_Original_ { get; set; }
        public string Nombre_ { get; set; }
        public bool Estado_ { get; set; }
        public int Duracion_ { get; set; }
        public string Director_ { get; set; }
        public List<Object> Protagonistas_ { get; set; }
        public string Clasificacion_ { get; set; }
        public string Imagen_ { get; set; }
    }
}