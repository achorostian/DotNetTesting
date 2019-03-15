using System.Web.Mvc;

namespace Twitter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Student,Admin,Member")]
        public ActionResult About()
        {
            ViewBag.Message = "You are seeing this message because you are authorised with one of Roles: Student, Admin, Member.";

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "You are seeing this message because you are Admin.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult EveryBodyTmp()
        {
            ViewBag.Message = "Everyone can see this message.";

            return View();
        }
    }
}