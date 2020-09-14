using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMWebApp.Models
{
    public class CommandResult
    {
        public CommandResult()
        {
            this.Errors = new List<string>();
        }

        public List<string> Errors { get; private set; }

        public bool IsValid => this.Errors.Count == 0;

        public object Response { get; set; }
    }
}