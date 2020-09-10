using PMWebApp.Facade;
using PMWebApp.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PMWebApp.Controllers
{
    public class SigninController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Projects");
            }

            SigninViewModel loginCred = new SigninViewModel();
            return View(loginCred);
        }

        [HttpPost]
        public ActionResult Index(SigninViewModel loginCred)
        {
            if (ModelState.IsValid)
            {
                AccessService access = new AccessService();

                if (access.GrantAccess(loginCred))
                {
                    return RedirectToAction("Index", "Projects");
                }
            } else
            {
                loginCred.isInvalid = true;
            }

            return View(loginCred);
        }

        

    }
}