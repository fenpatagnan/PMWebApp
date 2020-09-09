using PMWebApp.Facade;
using PMWebApp.Models.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMWebApp.Controllers
{
 
    public class ProjectsController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            var ProjectService = new ProjectService();
            
            return View(ProjectService.ListProjects());
        }

        public ActionResult Create()
        {
            var ProjectService = new ProjectService();
            ProjectService.AddNewProject();
            return Content("ddd");
        }


    }
}