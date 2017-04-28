using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gym.Models
{
    public class GymDbInitializer: CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames =
            {
                "Admin",
                "Trener",
                "Member"
            };

            foreach (var roleName in roleNames)
            {
                if (!roleManager.RoleExists(roleName))
                    roleManager.Create(new IdentityRole(roleName));
            }

            base.Seed(context);

        }
    }
}