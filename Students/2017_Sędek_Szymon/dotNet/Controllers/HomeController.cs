using System.Web.Mvc;

namespace dotNet.Controllers
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
            ViewBag.Message = "Widoczne tylko dla zalogowanego usera";

            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Widoczne tylko dla admina";

            return View();
        }
        [AllowAnonymous]
        public ActionResult EveryBodyTmp()
        {
            ViewBag.Message = "Widoczne dla każdego";

            return View();
        }
    }
}