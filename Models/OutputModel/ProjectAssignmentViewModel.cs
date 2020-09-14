using PMWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMWebApp.Models.OutputModel
{
    public class ProjectAssignmentViewModel
    {
        public ProjectDetailsOutputModel ProjectDetails { get; set; }

        public IEnumerable<ProjectMembersViewModel> Members { get; set; }
        public IEnumerable<ProjectNonMembersViewModel> NonMembers { get; set; }

    }
}