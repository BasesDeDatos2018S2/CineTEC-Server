using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTec.Models
{
    public class Report_Data
    {
        public string ID_Cliente { get; set; }
        public List<Object> Butacas_Ocupadas { get; set; }
        public int ID_Proyection { get; set; }

    }
}