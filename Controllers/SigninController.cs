using PMWebApp.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMWebApp.Controllers
{
    public class SigninController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginForm LoginInstance)
        {
            if (!ModelState.IsValid)
            {
                return View(LoginInstance);
            }

            return RedirectToAction("Index", "Home");
           
        }


    }
}