using PMWebApp.Facade;
using PMWebApp.Models.InputModel;
using PMWebApp.Models.OutputModel;
using System;
using System.Collections.Generic;
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
            var ProjectService = new ProjectService();
            
            return View(ProjectService.ListProjects());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateOrUpdateProjectInputModel projectInput)
        {
            var ProjectService = new ProjectService();
            ProjectService.CreateTheProject(projectInput);
            return View("Index");
        }


    }
}