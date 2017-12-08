using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class NewMenu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Details { get; set; }
        public bool Nuts { get; set; }
        public bool Shellfish { get; set; }
        public bool Soy { get; set; }
        public bool Eggs { get; set; }
        public bool Milk { get; set; }
        public decimal Price { get; set; }
    }
}