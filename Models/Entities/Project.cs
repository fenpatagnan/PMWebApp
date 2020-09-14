using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(8)]
        public string CodeValue { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Remarks { get; set; }

        [Required]
        public decimal Budget { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<PersonProject> PersonProjects { get; set; }
    }
}