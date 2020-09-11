using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.OutputModel
{
    public class AddOrUpdatePersonSuccessViewModel
    {
        public bool isSuccess { get; set; }
        public AddOrUpdatePersonSuccessViewModel(bool _isSuccess)
        {
           isSuccess = _isSuccess;
        }
    }
}