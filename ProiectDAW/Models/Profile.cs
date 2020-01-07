using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsPrivate { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}