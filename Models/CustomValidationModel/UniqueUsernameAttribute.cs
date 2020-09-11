using PMWebApp.Facade;
using PMWebApp.Models.InputModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.CustomValidationModel
{
    public class UniqueUsernameAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CreateOrUpdatePersonInputModel person = (CreateOrUpdatePersonInputModel)validationContext.ObjectInstance;

            PersonService personService = new PersonService();
           
            if (personService.IsUsernameDuplicate(person.username))
            {
                return new ValidationResult("Username is already taken.");
            }

            return ValidationResult.Success;
        }
    }
}