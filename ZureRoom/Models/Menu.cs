using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public int Ordering { get; set; }
        public string Beschrijving { get; set; }
        public bool Noten { get; set; }
        public bool Schelpdieren { get; set; }
        public bool Soya { get; set; }
        public bool Eieren { get; set; }
        public bool Melk { get; set; }
    }
}