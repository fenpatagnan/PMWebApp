using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMWebApp.Models.InputModel
{
    public class CreateOrUpdateProjectInputModel
    {
        [Required]
        [Remote("isProjectAvail", "Projects", AdditionalFields = "projectCode", ErrorMessage = "Project already unavailable")]
        [DisplayName("Project Code")]
        public string projectCode { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public string projectName { get; set; }

        [Required]
        [DisplayName("Project Budget")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,2})?)$", ErrorMessage = "Please enter a valid amount.")]
        [Range(0, 9999999999999999.99)]
        public decimal projectBudget { get; set; }

        [StringLength(255)]
        public string projectRemarks { get; set; }
        public bool isActive { get; set; }




    }
}