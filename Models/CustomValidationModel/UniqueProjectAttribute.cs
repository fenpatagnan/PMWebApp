using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PMWebApp.Core.Facade;
using PMWebApp.Core.Commands;


namespace PMWebApp.Models.CustomValidationModel
{
    public class UniqueProjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CreateOrUpdateProjectCommand project = (CreateOrUpdateProjectCommand)validationContext.ObjectInstance;

            ProjectService projectService = new ProjectService();

            if (projectService.IsProjectCodeDuplicate(project.projectCode))
            {
                return new ValidationResult("Project Code is already taken.");
            }

            return ValidationResult.Success;
        }
    }
    
}