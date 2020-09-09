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
            
            db.Projects.Add(
                new Project()
                {
                    CodeValue = "PRJ0002",
                    Name = projectInput.projectName,
                    Remarks = projectInput.projectRemarks,
                    Budget = projectInput.projectBudget,
                    IsActive = true
                });


            db.SaveChanges();
            return true;
        }

        public static string GenerateProjectCode()
        {
            string projectCode = "2wqe";
            return projectCode;
        }
    }
}