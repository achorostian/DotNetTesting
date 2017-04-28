using System;
using System.Web.Mvc;
using dotNet.Controllers;
using dotNet.Models;
using dotNet.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace testyyyy.Tests.Controllers
{
    [TestClass]
    public class CarControllerMoqTest
    {

        [TestMethod]
        public void TestDetailsValue()
        {
            var car =
                new Car
                {
                    CarId = 1,
                    Model = "Ford",
                    Vin = "ansmdkesndh",
                    Yop = 1998,

                };
            var context = new Mock<ICarContex>();
            context.Setup(a => a.FindCarById(1)).Returns(car);
            var carController = new CarsController(context.Object);
            var result = (ViewResult)carController.Details(1);
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void TestDeletePrepareCar()
        {

            var car = new Car
            {
                CarId = 4,
                Model = "Ford",
                Vin = "ansmdkesndh",
                Yop = 1998,

            };
            var context = new Mock<ICarContex>();
            context.Setup(a => a.FindCarById(4)).Returns(car);
            var carController = new CarsController(context.Object);
            var result = (ViewResult)carController.Delete(1);
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void TestDeleteConfirmCar()
        {
            var car = new Car
            {
                CarId = 4,
                Model = "Ford",
                Vin = "ansmdkesndh",
                Yop = 1998,

            };
            var context = new Mock<ICarContex>();
            context.Setup(a => a.FindCarById(4)).Returns(car);
            var carController = new CarsController(context.Object);
            var result = (RedirectToRouteResult)carController.DeleteConfirmed(4);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void TestEditView()
        {
            var car =
              new Car
              {
                  CarId = 4,
                  Model = "Ford",
                  Vin = "ansmdkesndh",
                  Yop = 1998,

              };
            var context = new Mock<ICarContex>();
            context.Setup(a => a.FindCarById(4)).Returns(car);
            var controller = new CarsController(context.Object);
            var result = controller.Edit(4) as ViewResult;
            var data = (Car)result.Model;
            Assert.IsTrue("Edit" == result.ViewName && "Ford" == data.Model);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestEditCar()
        {

            var context = new Mock<ICarContex>();
            context.Setup(a => a.FindCarById(65)).Returns((Car)null);
            var carController = new CarsController(context.Object);
            var result = carController.Edit(null);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        public void TestEditConfirmCar()
        {
            var car =
              new Car
              {
                  CarId = 4,
                  Model = "Ford",
                  Vin = "ansmdkesndh",
                  Yop = 1998,

              };
            var context = new Mock<ICarContex>();
            context.Setup(a => a.FindCarById(4)).Returns(car);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new CarsController(context.Object);
            car.Model = "Opel";
            car.Vin = "mdjsnrufkdsin";
            var result = controller.EditConfirm(car) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void TestEditConfirmNotValidCar()
        {
            var car =
             new Car
             {
                 CarId = 4,
                 Model = "Ford",
                 Vin = "ansmdkesndh",
                 Yop = 1998,

             };
            var context = new Mock<ICarContex>();
            context.Setup(a => a.FindCarById(4)).Returns(car);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var carController = new CarsController(context.Object);
            car.Model = "Opel";
            car.Vin = "dsin";
            carController.ViewData.ModelState.AddModelError("Vin", "Vin powinien mieć conajmniej 10 znaków");
            var result = (ViewResult)carController.EditConfirm(car);
            Assert.AreEqual("Edit", result.ViewName);
        }

    }
}
