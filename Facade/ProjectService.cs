using PMWebApp.Models.OutputModel;
using PMWebApp.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMWebApp.Models.Entities;
using PMWebApp.Models.InputModel;
using System.Diagnostics;
using PMWebApp.Models;

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

        public ProjectDetailsOutputModel GetProjectDetails(string projectCode)
        {
            var projectDetails = db.Projects.Where( c => c.CodeValue == projectCode).FirstOrDefault();

            ProjectDetailsOutputModel project = new ProjectDetailsOutputModel();

            if(projectDetails != null)
            {
                project.ProjectId = projectDetails.Id;
                project.ProjectCode = projectDetails.CodeValue;
                project.ProjectName = projectDetails.Name;
                project.ProjectBudget = projectDetails.Budget;
                project.ProjectRemarks = projectDetails.Remarks;
            }

            return project;
        }

        public bool UpdateTheProject(CreateOrUpdateProjectInputModel projectInput)
        {
           
            return true;
        }


        public List<ProjectNonMembersViewModel> GetUnassignedMembers(int projectId)
        {
            var unassignedMembers = db.People.SqlQuery("SELECT Id, Username, FirstName, Lastname, Password, DateCreated " +
                                                       "FROM PersonProjects " +
                                                       "RIGHT JOIN People ON PersonProjects.PersonId = People.Id " +
                                                       "AND PersonProjects.ProjectId = {0} " +
                                                       "WHERE PersonId IS NULL;", projectId).ToList<Person>();


            List<ProjectNonMembersViewModel> nonMembers = new List<ProjectNonMembersViewModel>();

            foreach (var unassignedMember in unassignedMembers)
            {
                nonMembers.Add(new ProjectNonMembersViewModel()
                {
                    PersonId = unassignedMember.Id,
                    LastName = unassignedMember.LastName,
                    FirstName = unassignedMember.FirstName
                });
            }

            return nonMembers;
        }

        public List<ProjectMembersViewModel> GetAssignedMembers(int projectId)
        {
            var assignedMembers = db.People.SqlQuery("SELECT * " +
                            "FROM PersonProjects " +
                            "LEFT JOIN People ON PersonProjects.PersonId = People.Id " +
                            "WHERE PersonProjects.ProjectId = 1;").ToList<Person>();

            List<ProjectMembersViewModel> nonMembers = new List<ProjectMembersViewModel>();

            foreach (var assignedMember in assignedMembers)
            {
                nonMembers.Add(new ProjectMembersViewModel()
                {
                    PersonId = assignedMember.Id,
                    LastName = assignedMember.LastName,
                    FirstName = assignedMember.FirstName
                });
            }

            return nonMembers;
        }

        public bool AddMemberToProject(AddMemberToProjectInputModel inputs)
        {
          
              db.PersonProject.Add( new PersonProject() {
                   ProjectId = inputs.ProjectId,
                   PersonId = inputs.PersonId,
               
              });

              db.SaveChanges();

              return true;

      }

       



    }
}