using System;
using System.Linq;
using System.Web.Mvc;
using dotNet.Controllers;
using dotNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testyyyy.Tests.Doubles;

namespace testyyyy.Tests.Controllers
{
    [TestClass]
    public class CarControllerTest
    {

  
        [TestMethod]
        public void TestDetailsNull()
        {
            var carController = new CarsController();
            var result = (HttpStatusCodeResult)carController.Details(null);
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public void TestDetailsValue()
        {
            var context = new FakeContext
            {
                Cars = new[]
                {
                     new Car{
                         CarId = 1,
                Model = "Ford",
                Vin = "ansmdkesndh",
                Yop = 1998,

                   }
                }.AsQueryable()
            };
            var carController = new CarsController(context);
            var result = (ViewResult)carController.Details(1);
            Assert.AreEqual("Details", result.ViewName);


        }
        [TestMethod]
        public void TestDeletePrepareCar()
        {
            var context = new FakeContext
            {
                Cars = new[]
                 {
                     new Car{
                         CarId = 1,
                Model = "Ford",
                Vin = "ansmdkesndh",
                Yop = 1998,

                   }
                }.AsQueryable()
            };
            var carController = new CarsController(context);
            var result = (ViewResult)carController.Delete(1);
            Assert.AreEqual("Delete", result.ViewName);
        }
        [TestMethod]
        public void TestDeleteConfirmCar()
        {
            var context = new FakeContext
            {
                Cars = new[]
                 {
                     new Car{
                         CarId = 1,
                Model = "Ford",
                Vin = "ansmdkesndh",
                Yop = 1998,

                   }
                }.AsQueryable()
            };
            var carController = new CarsController(context);
            var result = (RedirectToRouteResult)carController.DeleteConfirmed(1);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestEditCar()
        {
            var context = new FakeContext
            {
                Cars = new[]
                 {
                     new Car{
                         CarId = 1,
                Model = "Ford",
                Vin = "ansmdkesndh",
                Yop = 1998

                   }
                }.AsQueryable()
            };
            var carController = new CarsController(context);
            var result = carController.Edit(null);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }
        [TestMethod]
        public void TestEditConfirmCar()
        {
            var context = new FakeContext
            {
                Cars = new[]
                 {
                     new Car{
                         CarId = 1,
                Model = "Ford",
                Vin = "ansmdkesndh",
                Yop = 1998,

                   }
                }.AsQueryable()
            };
            var carModel = new Car
            {
                CarId = 1,
                Model = "Opel",
                Vin = "mdjsnrufkdsin",
            };
            var carController = new CarsController(context);
            var result = (RedirectToRouteResult)carController.EditConfirm(carModel);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
          }
        [TestMethod]
        public void TestEditConfirmNotValidCar()
        {
            var context = new FakeContext
            {
                Cars = new[]
                 {
                     new Car{
                         CarId = 1,
                Model = "Ford",
                Vin = "ansmdkesndh",
                Yop = 1998,

                   }
                }.AsQueryable()
            };
            var carModel = new Car
            {
                CarId = 1,
                Model = "Opel",
                Vin = "mn",
            };
            var carController = new CarsController(context);
            carController.ViewData.ModelState.AddModelError("Vin", "Vin powinien mieć conajmniej 10 znaków");
            var result = (ViewResult)carController.EditConfirm(carModel);
            Assert.AreEqual("Edit", result.ViewName);
        }

    }
}

