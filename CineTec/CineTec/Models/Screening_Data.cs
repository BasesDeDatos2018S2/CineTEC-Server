using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTec.Models
{
    public class Screening_Data
    {
        public int id { get; set; }
        public string hour { get; set; }
        public string date { get; set; }
        public int price { get; set; }
        public List<Object> Butacas_ocupadas { get; set; }
        public int id_movie { get; set; }
        public int id_movie_room { get; set; }
    }
}