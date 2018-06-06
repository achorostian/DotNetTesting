using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models.Main.Menager
{
    public class ApplicationRoleMenager
    {
        // Swap ApplicationRole for IdentityRole:
        private readonly RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(

         new RoleStore<IdentityRole>(new ApplicationDbContext())
            );

        private readonly ApplicationUserManager _userManager = new ApplicationUserManager(
            new ApplicationUserStore(new ApplicationDbContext())
            );

    
        public bool RoleExists(string name)
        {
            return _roleManager.RoleExists(name);
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
            var roles = _userManager.GetRoles(userId).ToArray();
            _userManager.RemoveFromRoles(userId, roles);
        }
    }
}