using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(200)]
        public string Username { get; set; }

        public string Lastname { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        ICollection<Project> Projects { get; set; }
    }
}