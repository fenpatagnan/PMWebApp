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
            return View();
        }

        [HttpPost]
        public ActionResult Index(SigninViewModel LoginInstance)
        {
            if (!ModelState.IsValid)
            {
                return View(LoginInstance);
            }

            FormsAuthentication.SetAuthCookie(LoginInstance.Username, false);

            return RedirectToAction("Index", "Home");
           
        }


    }
}