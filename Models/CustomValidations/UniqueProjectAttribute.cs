using PMWebApp.Core.Facade;
using PMWebApp.Core.Commands;
using System.ComponentModel.DataAnnotations;


namespace PMWebApp.Models.CustomValidations
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