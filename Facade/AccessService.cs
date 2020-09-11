using PMWebApp.Models.Context;
using PMWebApp.Models.InputModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace PMWebApp.Facade
{
    public class AccessService
    {
        ProjectsDbContext db = new ProjectsDbContext();
        public bool GrantAccess(SigninViewModel loginCred)
        {
           
            var userData = db.People.Where(u => u.Username == loginCred.username).FirstOrDefault();

            bool isPasswordValid = false;

            if(userData != null)
            {
                isPasswordValid = loginCred.password.Equals(userData.Password);

                if(isPasswordValid)
                {
                    FormsAuthentication.SetAuthCookie(userData.FirstName, false);
                }
            }
                      
            return isPasswordValid;

        }


    }
}