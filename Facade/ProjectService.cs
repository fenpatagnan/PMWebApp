using PMWebApp.Models.OutputModel;
using PMWebApp.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMWebApp.Models.Entities;
using PMWebApp.Models.InputModel;

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

        public bool CreateTheProject(CreateOrUpdateProjectInputModel projectInput)
        {
            if(!IsUnique(projectInput.projectCode))
            {
               db.Projects.Add(
               new Project()
               {
                   CodeValue = projectInput.projectCode,
                   Name = projectInput.projectName,
                   Remarks = projectInput.projectRemarks,
                   Budget = projectInput.projectBudget,
                   DateCreated = DateTime.Now,
                   IsActive = true
               });

               db.SaveChanges();
               projectInput.viewMessage = "New project has been created.";
               return true;
            }
           
            return false;
        }

        public bool IsUnique(string inputCode)
        {
            return db.Projects.Any(v => v.CodeValue == inputCode);
        }

        
    }
}