using PMWebApp.Models.Context;
using PMWebApp.Models.Entities;
using PMWebApp.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PMWebApp.Facade
{
    public class PersonService
    {
        ProjectsDbContext db = new ProjectsDbContext();
        public bool CreatePerson(CreateOrUpdatePersonInputModel personInput)
        {
            
            db.People.Add(
            new Person()
                {
                    LastName = personInput.lastName.Trim(),
                    FirstName = personInput.firstName.Trim(),
                    Username = personInput.username.Trim(),
                    Password = personInput.password,
                    DateCreated = DateTime.Now
            });

            db.SaveChanges();
            return true;
   
        }

        public bool IsUsernameDuplicate(string inputUsername)
        {
            return db.People.Any(v => v.Username == inputUsername);
        }

    }
}