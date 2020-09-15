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
            
            // always prefer CHUNKY interfaces than CHATTY ones.
            var projAssigment = new ProjectAssignmentViewModel().Initialize(this.projectService);

            return View(projAssigment);
        }

        [HttpPost]
        public ActionResult Assigning(AddMemberInProjectCommand  personProjectInput)
        {
            if (!ModelState.IsValid) return Content("error");
           
            bool isAdded = this.projectService.AddMemberToProject(personProjectInput);

            return Content(personProjectInput.PersonId.ToString() + " "+ personProjectInput.ProjectId.ToString() + isAdded.ToString());
        }


    }
}