using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your image URL")]
        public string Src { get; set; }

        public virtual Profile Profile { get; set; }

    }
}