using PMWebApp.Facade;
using PMWebApp.Models.InputModel;
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
            if (!ModelState.IsValid)
            {
                return View(personInput);
            }

            var personService = new PersonService();
           
            personInput.isUsernameTaken = personService.IsUsernameDuplicate(personInput.username);

            if(!personInput.isUsernameTaken)
            {
                ModelState.Clear();
                personInput.isSuccess = personService.CreatePerson(personInput);
            }


            return View("Create", personInput);
        }
    }
}