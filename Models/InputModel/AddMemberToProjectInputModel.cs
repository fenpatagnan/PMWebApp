using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.InputModel
{
    public class AddMemberToProjectInputModel
    {
        public int ProjectId { get; set; }
        public int PersonId { get; set; }

    }
}