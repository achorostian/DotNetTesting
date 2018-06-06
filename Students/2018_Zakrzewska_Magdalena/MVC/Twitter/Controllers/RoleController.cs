using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Models.Main;
using Twitter.Models.Main.Menager;
using Twitter.Models.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Twitter.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly ApplicationDbContext _context;
        public RoleController()
        {
            _context = new ApplicationDbContext();
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            var rolesList = new List<RoleViewModel>();
            foreach (var role in _context.Roles)
            {
                var roleModel = new RoleViewModel(role);
                rolesList.Add(roleModel);
            }
            return View(rolesList);
        }


        public ActionResult ShowAllUsersWithRole()
        {
            var userRoles = _context.Roles.ToList();
            List<UserRolesViewModel> userList = new List<UserRolesViewModel>();
            foreach (var user in userRoles)
            {
                userList.AddRange(user.Users.Select(rola => new UserRolesViewModel
                {
                    Email = _context.Users.Find(rola.UserId).Email,
                    Rola = user.Name
                }));
            }
            var model = userList;
            return View(model);
        }

        public ActionResult ShowCurrentUserRoles()
        {
            List<UserRolesViewModel> model = new List<UserRolesViewModel>();
            var currentUser = User.Identity.GetUserId();
            var role = _context.Roles.Where(a => a.Users.Any(b => b.UserId == currentUser));
            foreach (var rola in role)
            {
                var tmp = new UserRolesViewModel
                {
                    Email = User.Identity.GetUserName(),
                    Rola = rola.Name
                };
                model.Add(tmp);
            }

            return View(model);
        }

        //get users to role
        [AllowAnonymous]
        [HttpGet]
        public ActionResult RegisterRole()
        {
            ViewBag.Name = new SelectList(_context.Roles.ToList(), "Name", "Name");
            ViewBag.Email = new SelectList(_context.Users.ToList(), "Email", "Email");
            return View();
        }
        // POST: /Role/RegisterRole
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterRole(ApplicationUser user, IdentityRole role)
        {
            var currentUser = UserManager.FindByEmail(user.Email);
            var menageRole = new ApplicationRoleMenager();
            menageRole.ClearUserRoles(currentUser.Id);
            if (!currentUser.Roles.Any())
            {
                menageRole.AddUserToRole(currentUser.Id, role.Name);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveUserFromRole(string emailUser, string roleName)
        {
            var idUser = _context.Users.First(a => a.Email == emailUser);
            var idManager = new ApplicationRoleMenager();
            idManager.RemoveFromRole(idUser.Id, roleName);
            idUser = _context.Users.First(a => a.Email == emailUser);
            if (!idUser.Roles.Any())
            {
                idManager.AddUserToRole(idUser.Id, "Member");
            }
            return RedirectToAction("Index", "Role");
        }

    }
}