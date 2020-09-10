using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.InputModel
{
    public class SigninViewModel
    {
       
        [Required]
        [StringLength(200, MinimumLength = 5)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter valid email address.")]
        public string username { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 5)]
        public string password { get; set; }

        public bool isInvalid = false;

    }
}