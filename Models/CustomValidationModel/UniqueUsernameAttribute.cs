using PMWebApp.Models.InputModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PMWebApp.Core.Facade;
using PMWebApp.Core.Commands;

namespace PMWebApp.Models.CustomValidationModel
{
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CreateOrUpdateProjectCommand person = (CreateOrUpdateProjectCommand)validationContext.ObjectInstance;

            PersonService personService = new PersonService();
           
            if (personService.IsUsernameDuplicate(person.username))
            {
                return new ValidationResult("Username is already taken.");
            }

            return ValidationResult.Success;
        }
    }
}