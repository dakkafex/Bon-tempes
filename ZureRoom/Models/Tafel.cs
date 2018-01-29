using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Tafel
    {
        public int Id { get; set; }
        public string TableNmr { get; set; }
        public int Chairs { get; set; }
        public string Combined { get; set; }
    }
}