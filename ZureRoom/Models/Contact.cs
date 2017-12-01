using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string TelefoonNmr { get; set; }
        public string Bericht { get; set; }
        public bool Gecontacteerd { get; set; }
    }
}