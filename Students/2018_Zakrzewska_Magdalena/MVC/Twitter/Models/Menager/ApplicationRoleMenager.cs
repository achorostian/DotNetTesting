using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gym.Models.Main;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gym.Models.Menager
{
    public class ApplicationRoleMenager
    {
        // Swap ApplicationRole for IdentityRole:
        RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(
         new RoleStore<IdentityRole>(new ApplicationDbContext()));
        ApplicationUserManager _userManager = new ApplicationUserManager(
        new ApplicationUserStore(new ApplicationDbContext()));
        
        ApplicationDbContext _context;

        public ApplicationRoleMenager()
        {
           _context = new ApplicationDbContext();

        }
        public bool RoleExists(string name)
        {
            return _roleManager.RoleExists(name);
        }


        public bool CreateRole(string name)
        {
            // Swap ApplicationRole for IdentityRole:
            var idResult = _roleManager.Create(new IdentityRole(name));
            return idResult.Succeeded;
        }



        public void RemoveFromRole(string userId, string roleName)
        {
            _userManager.RemoveFromRole(userId, roleName);
        }

        public void AddUserToRole(string userId, string roleName)
        {
             _userManager.AddToRole(userId, roleName);
            
        }


        public void ClearUserRoles(string userId)
        {
            var user = _userManager.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();

            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                _userManager.RemoveFromRole(userId, role.RoleId);
            }
        }
    }
}