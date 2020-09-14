using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.OutputModel
{
    public class ProjectDetailsOutputModel
    {
        public int ProjectId { get; set; }
       
        public string ProjectCode { get; set; }
        
        public string ProjectName { get; set; }
        
        public decimal ProjectBudget { get; set; }

        public string ProjectRemarks { get; set; }

    }
}