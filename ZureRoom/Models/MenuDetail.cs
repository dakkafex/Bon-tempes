using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class MenuDetail
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MenuImage { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Nuts { get; set; }
        public bool Shellfish { get; set; }
        public bool Soy { get; set; }
        public bool Eggs { get; set; }
        public bool Milk { get; set; }
    }
}