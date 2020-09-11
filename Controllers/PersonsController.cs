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
    public class PersonsController : Controller
    {
        // GET: Persons
        [HttpGet]
        public ActionResult Create()
        {
            CreateOrUpdatePersonInputModel personInput = new CreateOrUpdatePersonInputModel();
            return View(personInput);
        }

        [HttpPost]
        public ActionResult Create(CreateOrUpdatePersonInputModel personInput)
        {
            if (ModelState.IsValid)
            {
                var personService = new PersonService();
                personInput.isSuccess = personService.CreatePerson(personInput);
                return View("SuccessPage");
            }

            return View(personInput);
        }
    }
}