﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Access { get; set; }
    }
}