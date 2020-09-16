using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMWebApp.Core.Facade;
using PMWebApp.Core.Commands;

namespace PMWebApp.Controllers
{
    [Authorize]
    public class PersonsController : Controller
    {
        // GET: Persons
        [HttpGet]
        public ActionResult Create()
        {
            CreateOrUpdatePersonCommand personInput = new CreateOrUpdatePersonCommand();
            return View(personInput);
        }

        [HttpPost]
        public ActionResult Create(CreateOrUpdatePersonCommand personInput)
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