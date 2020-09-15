using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PMWebApp.Facade;

namespace PMWebApp.Controllers
{
    public class SigninController : Controller
    {
        private readonly AccessService accessService;

        public SigninController() : this(null) { }

        public SigninController(AccessService accessService)
        {
            this.accessService = accessService ?? new AccessService();
        }

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
        public ActionResult Index(SigninCommand loginCred)
        {
            if (!ModelState.IsValid)
            {
                return View(loginCred);
            }

            if (accessService.GrantAccess(loginCred))
            {
                return RedirectToAction("Index", "Projects");
            }

            return View(loginCred);
        }

        

    }
}