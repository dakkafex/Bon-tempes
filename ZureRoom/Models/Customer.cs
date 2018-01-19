using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [DisplayName("Naam")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [DisplayName("Telefoonnummer")]
        [Required]
        [MaxLength(10)]
        public int Phone { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}