using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTec.Models
{
    public class MoviesWithScreening
    {
        public int id { get; set; }
        public string Nombre_Original { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public int Duracion { get; set; }
        public string Director { get; set; }
        public List<Object> Proyecciones { get; set; }
        public string Clasificacion { get; set; }
        public string Imagen { get; set; }

    }
}