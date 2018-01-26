using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZureRoom.Models
{
    public class MenuImg
    {
        [Key]
        public int Id { get; set; }
        public string MenuImgPlace { get; set; }
    }
}