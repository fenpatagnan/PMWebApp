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
        public string Code { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Remarks { get; set; }
        public decimal Budget { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? DateCreated { get; set; }
    }
}