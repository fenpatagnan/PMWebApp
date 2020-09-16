using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMWebApp.Core.Commands;
using PMWebApp.Core.Facade;
using PMWebApp.Core.Data;
using PMWebApp.Core.ViewModels;

namespace PMWebApp.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ProjectService projectService = new ProjectService();
        private PersonService personService = new PersonService();
        // GET: Project
        public ActionResult Index()
        {
            var projectService = new ProjectService();          
            return View(projectService.ListProjects());
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateOrUpdateProjectCommand project = new CreateOrUpdateProjectCommand();
            return View(project);
        }

        [HttpPost]
        public ActionResult Create(CreateOrUpdateProjectCommand projectInput)
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
            var projectService = new ProjectService();
            return Json(projectService.IsProjectCodeDuplicate(projectCode), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var projectService = new ProjectService();
            ProjectDetailData project = projectService.GetProjectDetails(id);
            return View(project);
        }

        [HttpGet]
        public ActionResult Assignments(string id)
        {
            if (string.IsNullOrEmpty(id)) return HttpNotFound();
            ProjectDetailData projectDetails = this.projectService.GetProjectDetails(id);
            return View(projectDetails);
        }

        [HttpPost]
        public ActionResult Assign(AddMemberInProjectCommand  personProjectInput)
        {
            CommandResult result = new CommandResult();

            if (!ModelState.IsValid) {
                result.Errors.Add("You must select a member to add.");
            } else
            {
                result = this.projectService.AddMemberToProject(personProjectInput);
            }
            return PartialView("~/Views/Projects/Partials/_ProjectAssignmentResponse.cshtml", result);
        }

        [HttpPost]
        public ActionResult Remove(RemoveMemberInProjectCommand personProjectInput)
        {
            CommandResult result = new CommandResult();

            if (!ModelState.IsValid)
            {
                result.Errors.Add("You must select a member to remove.");
            }
            else
            {
                result = this.projectService.RemoveMemberToProject(personProjectInput);
            }
           
            return PartialView("~/Views/Projects/Partials/_ProjectAssignmentResponse.cshtml", result);

        }

        [HttpGet]

        public ActionResult GetProjectAssignmentDetails(string id)
        {
            var projAssignment = new ProjectAssignmentViewModel().Initialize(this.projectService, this.personService, id);
            return PartialView("~/Views/Projects/Partials/_ProjectAssignments.cshtml", projAssignment);
        }


    }
}