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
            if(isUnique(projectInput.projectCode))
            {
               db.Projects.Add(
               new Project()
               {
                   CodeValue = projectInput.projectCode,
                   Name = projectInput.projectName,
                   Remarks = projectInput.projectRemarks,
                   Budget = projectInput.projectBudget,
                   IsActive = true
               });

               db.SaveChanges();
               return true;
            }
           
            return false;
        }

        public bool isUnique(string inputCode)
        {
            var code = db.Projects.Where(v => v.CodeValue == inputCode).FirstOrDefault();
            return (code == null ? true : false);
             
            
        }

        public bool checkAvailability(string ProjectCode)
        {

            var code = db.Projects.Where(v => v.CodeValue == ProjectCode).FirstOrDefault();
            return (code == null ? true : false);
        }
    }
}