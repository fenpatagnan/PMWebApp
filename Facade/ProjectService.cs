using PMWebApp.Models.OutputModel;
using PMWebApp.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMWebApp.Models.Entities;
using PMWebApp.Models.InputModel;
using System.Diagnostics;

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
                    projectCode = project.CodeValue.Trim(),
                    projectName = project.Name.Trim(),
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
                    CodeValue = projectInput.projectCode,
                    Name = projectInput.projectName,
                    Remarks = projectInput.projectRemarks,
                    Budget = projectInput.projectBudget,
                    DateCreated = DateTime.Now,
                    IsActive = true
            });

            db.SaveChanges();
            return true;
        }

        public bool IsProjectCodeDuplicate(string inputCode)
        {
            return db.Projects.Any(v => v.CodeValue == inputCode);
        }

        public CreateOrUpdateProjectInputModel GetProjectDetails(string projectCode)
        {
            var projectDetails = db.Projects.Where( c => c.CodeValue == projectCode).FirstOrDefault();

            CreateOrUpdateProjectInputModel project = new CreateOrUpdateProjectInputModel();

            if(projectDetails != null)
            {
                project.projectName = projectDetails.Name;
                project.projectBudget = projectDetails.Budget;
                project.projectRemarks = projectDetails.Remarks;
                project.projectCode = projectDetails.CodeValue;
            }

            return project;
        }



    }
}