using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public int Count { get; set; }
        public int Size { get; set; }
    }
}