using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models.Main
{
    public class DotNetDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
              var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
               string[] roleNames =
               {
                   "Admin",
                   "Student",
                   "Member"
               };

               foreach (var roleName in roleNames)
               {
                   if (!roleManager.RoleExists(roleName))
                       roleManager.Create(new IdentityRole(roleName));
               }
            var listArt = new List<Tweet>();
            var art1 = new Tweet
            {
                Title = "pierwszy",
                Description = "fajny"
            };
            var art2 = new Tweet
            {
                Title = "drugi",
                Description = "fajny bardzo"
            };
            listArt.Add(art2);
            listArt.Add(art1);
            listArt.ForEach(a => context.Tweets.Add(a));
            context.SaveChanges();

            base.Seed(context);

        }
    }
}