﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Contact
    {
        public int ID { get; set; }
        [DisplayName("Naam")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [DisplayName("Telefoonnummer")]
        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }
        [DisplayName("Bericht")]
        [Required]
        [MinLength(1)]
        public string Message { get; set; }
        public bool Resolved { get; set; }
    }
}