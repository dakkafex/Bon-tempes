using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZureRoom.Models;

namespace ZureRoom.ViewModel
{
    public class ReserverenViewModel
    {
        public IEnumerable<Reservation> Reservation { get; set; }
        public IEnumerable<Menu> Menu { get; set; }
    }
}