using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PMWebApp.Controllers
{
    public class SignoutController : Controller
    {
        // GET: Signout
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Signin");
        }
    }
}