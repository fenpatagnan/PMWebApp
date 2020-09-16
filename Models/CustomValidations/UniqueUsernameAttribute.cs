using System.ComponentModel.DataAnnotations;
using PMWebApp.Core.Facade;
using PMWebApp.Core.Commands;


namespace PMWebApp.Models.CustomValidations
{
    public class UniqueUsernameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            CreateOrUpdatePersonCommand person = (CreateOrUpdatePersonCommand)validationContext.ObjectInstance;

            PersonService personService = new PersonService();
           
            if (personService.IsUsernameDuplicate(person.username))
            {
                return new ValidationResult("Username is already taken.");
            }

            return ValidationResult.Success;
        }
    }
}