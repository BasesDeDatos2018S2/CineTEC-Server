using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTec.Models
{
    public class Compra_Butaca_Data
    {
        public int screening { get; set; }
        public string client { get; set; }
        public List<Par_Butaca> butacas { get; set; }
    }
}