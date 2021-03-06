﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CineTec.Models
{
    public class Client_Data_Report
    {
        public string identification { get; set; }
        public string name { get; set; }
        public string lastname1 { get; set; }
        public string lastname2 { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public LinkedList<Object> Projects { get; set; }
    }
}