using PMWebApp.Facade;
using PMWebApp.Models;
using PMWebApp.Models.Entities;
using PMWebApp.Models.InputModel;
using PMWebApp.Models.OutputModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMWebApp.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ProjectService projectService = new ProjectService();
        // GET: Project
        public ActionResult Index()
        {
            var projectService = new ProjectService();          
            return View(projectService.ListProjects());
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateOrUpdateProjectInputModel project = new CreateOrUpdateProjectInputModel();
            return View(project);
        }

        [HttpPost]
        public ActionResult Create(CreateOrUpdateProjectInputModel projectInput)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", projectInput);
            }

            var projectService = new ProjectService();
            projectInput.isSuccess = projectService.CreateTheProject(projectInput);
            return View("SuccessPage");
        }

        public JsonResult IsProjectAvail(string projectCode)
        {
            // RESTful semantics
            //   All queries: HTTP GET
            //   All commands: HTTP POST
            var projectService = new ProjectService();
            return Json(projectService.IsProjectCodeDuplicate(projectCode), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var projectService = new ProjectService();
            ProjectDetailsOutputModel project = projectService.GetProjectDetails(id);
            return View(project);
        }

        [HttpGet]
        public ActionResult Assignments(string id)
        {
            ProjectAssignmentViewModel projAssignment = new ProjectAssignmentViewModel();

            projAssignment.ProjectDetails = this.projectService.GetProjectDetails(id);

            projAssignment.Members = this.projectService.GetAssignedMembers(projAssignment.ProjectDetails.ProjectId);

            projAssignment.NonMembers = this.projectService.GetUnassignedMembers(projAssignment.ProjectDetails.ProjectId);

            return View(projAssignment);
        }

        [HttpPost]
        public ActionResult Assigning(AddMemberToProjectInputModel  personProjectInput)
        {
            bool x = this.projectService.AddMemberToProject(personProjectInput);

            return Content(personProjectInput.PersonId.ToString() + " "+ personProjectInput.ProjectId.ToString());
        }


    }
}