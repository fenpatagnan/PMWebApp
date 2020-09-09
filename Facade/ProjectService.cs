using PMWebApp.Models.OutputModel;
using PMWebApp.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMWebApp.Facade
{
    public class ProjectService
    {
        ProjectsDbContext db = new ProjectsDbContext();
        public List<ProjectsViewModel> ListProjects()
        {
            List<ProjectsViewModel> projectList = new List<ProjectsViewModel>();

            var projects = db.Projects.ToList();

            foreach (var project in projects)
            {
                projectList.Add( new ProjectsViewModel() {
                    projectCode = project.CodeValue,
                    projectName = project.Name,
                    projectBudget = project.Budget,
                    isActive = project.IsActive
                });
            }
            
            return projectList;
            
        }
    }
}