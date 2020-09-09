using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.InputModel
{
    public class LoginForm
    {
       
        [Required]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter valid email address.")]
        public string Username { get; set; }

        [Required]
        [MinLength(5, ErrorMessage ="Invalid password length.")]
        [MaxLength(11, ErrorMessage = "Invalid password length.")]
        public string Password { get; set; }

       

    }
}