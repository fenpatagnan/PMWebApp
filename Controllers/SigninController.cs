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
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Projects");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(SigninViewModel loginInstance)
        {
            if (!ModelState.IsValid)
            {
                return View(loginInstance);
            }

            FormsAuthentication.SetAuthCookie(loginInstance.Username, false);

            return RedirectToAction("Index", "Projects");
           
        }

        

    }
}