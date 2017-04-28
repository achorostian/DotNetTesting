using System.Collections.Generic;
using System.Data.Entity;
using dotNet.Models.Main.Menager;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dotNet.Models.Main
{
    public class DotNetDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //var idManager = new ApplicationRoleMenager();
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
            var listArt = new List<Artist>();
            var art1 = new Artist
            {
                Name = "stefa",
                Description = "fajny"
            };
            var art2 = new Artist
            {
                Name = "arek",
                Description = "fajny bardzo"
            };
            listArt.Add(art2);
            listArt.Add(art1);
            listArt.ForEach(a => context.Artists.Add(a));
            context.SaveChanges();
            var listCar = new List<Car>();
            var car1 = new Car
            {
                Model = "Ford",
                Vin = "ansmdkesndh",
                Yop = 1998,
                ArtId = null
                
            };
            var car2 = new Car
            {
                Model = "Mazda",
                Vin = "mskfhdbsncjdhf",
                Yop = 2014,
                ArtId = null
                
            };
            listCar.Add(car2);
            listCar.Add(car1);
            listCar.ForEach(s => context.Cars.Add(s));
            context.SaveChanges();
         


            base.Seed(context);

        }
    }
}