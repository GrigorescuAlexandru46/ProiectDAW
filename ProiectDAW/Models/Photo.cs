using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Src { get; set; }

        public virtual Profile Profile { get; set; }
    }
}