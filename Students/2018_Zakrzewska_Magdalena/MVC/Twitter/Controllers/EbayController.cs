using System.Web.Mvc;
using Twitter.Service;
using Twitter.Models.Ebay;
using Twitter.Models;
using System;
using System.Threading.Tasks;

namespace Twitter.Controllers
{
    public class EbayController : Controller
    {
        private readonly IEbayContext db;

        public EbayController()
        {
            db = new EbayContext();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Create()
        {
            var output = await GetEbayInformations("findItemsAdvanced");

            db.Add<Items>(output);
            db.SaveChanges();

            return View();
        }

        private async Task<Items> GetEbayInformations(string call)
        {
            EbayService service = new EbayService();
            var output = await service.GetEbayCall(call);

            return output;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            EbaySummary summary = new EbaySummary();
            summary.SaveDate = new DateTime();
            summary.PriceAverage = db.Average();

            return View(summary);
        }
    }
}