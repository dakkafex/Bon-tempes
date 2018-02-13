using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZureRoom.Models;

namespace ZureRoom.ViewModel
{
    public class ReserverenEnTafelViewModel
    {
        public IEnumerable<Tafel> Tafel { get; set; }
        public IEnumerable<Reservation> Reservation { get; set; }
    }
}