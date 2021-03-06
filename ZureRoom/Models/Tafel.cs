﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Tafel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Tafel nummer")]
        public int TableNmr { get; set; }
        [Required]
        [DisplayName("Stoelen")]
        public int Chairs { get; set; }
    }
}