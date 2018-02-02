using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Menu
    {
        public int ID { get; set; }
        [DisplayName("Naam")]
        public string Name { get; set; }
        [Display(Name = "Menu plaatje")]
        public virtual MenuImg MenuImg { get; set; }
        [DisplayName("Beschrijving")]
        public string Description { get; set; }
        [DisplayName("Noten")]
        public bool Nuts { get; set; }
        [DisplayName("Schelpdieren")]
        public bool Shellfish { get; set; }
        [DisplayName("Soja")]
        public bool Soy { get; set; }
        [DisplayName("Eieren")]
        public bool Eggs { get; set; }
        [DisplayName("Melk")]
        public bool Milk { get; set; }
        [DisplayName("Prijs")]
        public decimal Price { get; set; }

        //[ForeignKey("Category")]
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }
    }
}