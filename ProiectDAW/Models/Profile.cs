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

        [Required(ErrorMessage = "Please enter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your age")]
        [Range(12, 120, ErrorMessage = "Age must be between 12 and 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}