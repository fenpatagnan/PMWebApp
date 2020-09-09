using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.OutputModel
{
    public class ProjectsViewModel
    {
        public string projectCode { get; set; }
        public string projectName { get; set; }
        public decimal projectBudget { get; set; }
        public string projectRemarks { get; set; }
        public bool isActive { get; set; }
    }
}