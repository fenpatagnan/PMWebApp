using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.InputModel
{
    public class CreateOrUpdateProjectInputModel
    {
        [Required]
        public string projectCode { get; set; }

        [Required]
        public string projectName { get; set; }

        [Required]
        public decimal projectBudget { get; set; }
        public string projectRemarks { get; set; }
        public bool isActive { get; set; }


    }
}