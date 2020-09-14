using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.Entities
{
    public class PersonProject
    {
        [Key, Column(Order = 1)]
        public int ProjectId { get; set; }

        [Key, Column(Order = 2)]
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Project Project { get; set; }
    }
}