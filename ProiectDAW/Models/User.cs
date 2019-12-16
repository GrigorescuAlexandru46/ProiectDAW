using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age;
        public string description { get; set; }
    }

    public class UserDBContext : DbContext
    {
        public UserDBContext() : base("DBConnectionString") { }
        public DbSet<User> Users { get; set; }
    }
}