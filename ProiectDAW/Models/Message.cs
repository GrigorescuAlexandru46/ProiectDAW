using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your message before sending")]
        public string Text { get; set; }

        public virtual Profile SenderProfile { get; set; }
    }
}