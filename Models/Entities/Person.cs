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
        [StringLength(200, MinimumLength = 5)]
        public string Username { get; set; }

        [StringLength(11, MinimumLength = 5)]
        public string Password { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        public DateTime? DateCreated { get; set; }

    }
}