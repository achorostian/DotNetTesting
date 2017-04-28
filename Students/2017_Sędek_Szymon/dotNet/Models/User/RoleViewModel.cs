using Microsoft.AspNet.Identity.EntityFramework;

namespace dotNet.Models.User
{
    public class RoleViewModel
    {
        public string RoleName { get; set; }
        public RoleViewModel() { }
        public RoleViewModel(IdentityRole role)
        {
            this.RoleName = role.Name;
        }
    }


    public class EditRoleViewModel
    {
        public string OriginalRoleName { get; set; }
        public string RoleName { get; set; }
        
        public EditRoleViewModel() { }
        public EditRoleViewModel(IdentityRole role)
        {
            this.OriginalRoleName = role.Name;
            this.RoleName = role.Name;
        }
    }

    public class ListRoleUsersViewModel
    {
        public string Email { get; set; }


    }
}