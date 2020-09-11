using PMWebApp.Facade;
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
            if(ModelState.IsValid)
            {
                var projectService = new ProjectService();
                projectInput.isSuccess = projectService.CreateTheProject(projectInput);
                return View("SuccessPage");
            }

            return View("Create", projectInput);
        }

        [HttpPost]
        public JsonResult IsProjectAvail(string projectCode)
        {
            var projectService = new ProjectService();
            return Json(projectService.IsProjectCodeDuplicate(projectCode), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
          
            CreateOrUpdateProjectInputModel project = new CreateOrUpdateProjectInputModel();

            var projectService = new ProjectService();
            project = projectService.GetProjectDetails(id);

            Debug.WriteLine(project.projectName + "Proj Name");

            return View(project);
        }

        public ActionResult Assign(string projectCode)
        {
            return HttpNotFound();
        }


    }
}