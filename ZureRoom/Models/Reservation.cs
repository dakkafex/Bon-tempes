using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        [DisplayName("Menu")]
        public string MenuName { get; set; }
        [DisplayName("Aantal")]
        [Range(1, 10)]
        public int Amount { get; set; }
        [DisplayName("Naam")]
        
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Email")]
        
        [MaxLength(50)]
        public string Email { get; set; }
        [DisplayName("Telefoonnummer")]
        
        [MaxLength(10)]
        public string Phone { get; set; }
        [DisplayName("Groepsgrootte")]
        [Range(1, 10)]
        
        public int Size { get; set; }
        [DisplayName("Prijs")]
        public Decimal Price { get; set; }
        [DisplayName("Bericht")]
        [MaxLength(250)]
        public string Message { get; set; }
        [DisplayName("Datum")]
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


        public int Tafel { get; set; }
    }
}