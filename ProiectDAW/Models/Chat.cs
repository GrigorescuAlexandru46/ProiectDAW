﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        public virtual Profile Profile1 { get; set; }
        public virtual Profile Profile2 { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}