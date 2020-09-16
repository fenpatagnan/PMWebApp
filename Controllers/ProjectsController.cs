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
            ProjectDetailData project = projectService.GetProjectDetails(id);
            return View(project);
        }

        [HttpGet]
        public ActionResult Assignments(string id)
        {

            var projAssignment = new ProjectAssignmentViewModel().Initialize(this.projectService, this.personService, id);

            return View(projAssignment);
        }

        [HttpPost]
        public ActionResult Assign(AddMemberInProjectCommand  personProjectInput)
        {
            CommandResult isAdded = new CommandResult();

            if (!ModelState.IsValid) isAdded.Errors.Add("Project Id or Person must have a value.");
           
            isAdded = this.projectService.AddMemberToProject(personProjectInput);

            return PartialView("~/Views/Projects/Partials/_ProjectAssignmentResponse.cshtml", isAdded);

        }

        [HttpPost]
        public ActionResult Remove(RemoveMemberInProjectCommand personProjectInput)
        {
            CommandResult isRemove = new CommandResult();

            if (!ModelState.IsValid) isRemove.Errors.Add("Project Id or Person must have a value.");
          
            isRemove = this.projectService.RemoveMemberToProject(personProjectInput);

            return PartialView("~/Views/Projects/Partials/_ProjectAssignmentResponse.cshtml", isRemove);

        }


    }
}