using MVCTraining.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVCTraining.Extensions
{
    public static class IdentityExtensions
    {
        // user account operations

        public static string GetUserFirstName(this IIdentity identity)
        {
            var db =  ApplicationDbContext.Create();

            var user = db.Users.FirstOrDefault(u => u.UserName.Equals(identity.Name));

            return user != null ? user.FirstName : String.Empty;
        }

    }
}