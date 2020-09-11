using PMWebApp.Models.CustomValidationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.InputModel
{
    public class CreateOrUpdatePersonInputModel
    {
        [Required]
        [StringLength(200, MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Username")]
        [UniqueUsername]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter valid email address.")]
        public string username { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 7)]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*[0-9])[A-Za-z0-9.\/\+@_%\$#!\^\&\(\)\*]+$", ErrorMessage = "Password must contain alphanumeric characters without space(s).")]
        [DisplayName("Password")]
        public string password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Numbers and special characters are not allowed")]
        public string lastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("First Name")]
        [RegularExpression(@"^[a-zA-Z, ]*$", ErrorMessage = "Numbers and special characters are not allowed.")]
        public string firstName { get; set; }

        public DateTime? dateCreated { get; set; }

        public bool isSuccess = false;

        public bool isUsernameTaken = false;
    }
}