using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using dotNet.Controllers.ActionFilter;
using dotNet.Models;
using dotNet.Models.Main;
using dotNet.Service;

namespace dotNet.Controllers
{
    //[Authorize(Roles = "Student,Admin")]
    [HandleError(View = "Error")]
    [ValueReport]
    public class CarsController : Controller
    {

        private readonly ICarContex _context;

        //Constructors
        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        public CarsController(ICarContex context)
        {
            _context = context;
        }
        // GET: Cars
        public ActionResult Index()
        {
            return View("Index",_context.Cars.ToList());
        }


        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _context.FindCarById(id.Value);
            return View("Details", car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.ArtId = new SelectList(_context.Artists, "ArtistId", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarId,Model,Yop,Vin,ArtId")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArtId = new SelectList(_context.Artists, "ArtistId", "Name", car.ArtId);
            return View(car);
        }

        [HandleError(ExceptionType = typeof(Exception))]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }
            var car = _context.FindCarById(id.Value);
          
            return View("Edit",car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm([Bind(Include = "CarId,Model,Yop,Vin,ArtId")] Car car)
        {
            if (ModelState.IsValid)
            {
                Car prepareCar = _context.FindCarById(car.CarId);
                prepareCar.Model = car.Model;
                prepareCar.Yop = car.Yop;
                prepareCar.ArtId = car.ArtId;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
          
            return View("Edit",car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = _context.FindCarById(id.Value);
            return View("Delete", car);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = _context.FindCarById(id);
            _context.Delete(car);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
