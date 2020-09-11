using PMWebApp.Facade;
using PMWebApp.Models.InputModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.CustomValidationModel
{
    public class UniqueProjectAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CreateOrUpdateProjectInputModel project = (CreateOrUpdateProjectInputModel)validationContext.ObjectInstance;

            ProjectService projectService = new ProjectService();

            if (projectService.IsProjectCodeDuplicate(project.projectCode))
            {
                return new ValidationResult("Project Code is already taken.");
            }

            return ValidationResult.Success;
        }
    }
    
}