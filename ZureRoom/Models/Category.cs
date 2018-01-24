using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Categorie")]
        public string Name { get; set; }
    }
}