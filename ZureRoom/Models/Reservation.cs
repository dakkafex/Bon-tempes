using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public string MenuName { get; set; }
        public int Amount { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Size { get; set; }
        public Decimal Price { get; set; }
    }
}