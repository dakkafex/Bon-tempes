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
        [Required]
        public int Amount { get; set; }
        [DisplayName("Naam")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Email")]
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [DisplayName("Telefoonnummer")]
        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }
        [DisplayName("Groepsgrootte")]
        [Required]
        public int Size { get; set; }
        [DisplayName("Prijs")]
        public Decimal Price { get; set; }
    }
}