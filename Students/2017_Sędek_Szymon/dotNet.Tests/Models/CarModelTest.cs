using dotNet.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testyyyy.Tests.Helpers;

namespace testyyyy.Tests.Models
{
    [TestClass]
    public class CarModelTest
    {
        [TestMethod]
        public void YopMinValueValidate()
        {
            var car = new Car {Yop = 1};
            var result = ModelValidHelper.Validate(car);
            Assert.AreEqual("Auto nie może być starsze niż 1900 rok i nowsze niż obecny rok.",result[0].ErrorMessage);
        }
        [TestMethod]
        public void YopMaxValueValidate()
        {
            var car = new Car { Yop = 2048 };
            var result = ModelValidHelper.Validate(car);
            Assert.AreEqual("Auto nie może być starsze niż 1900 rok i nowsze niż obecny rok.", result[0].ErrorMessage);
        }
        [TestMethod]
        public void YopConfirmValidate()
        {
            var car = new Car { Yop = 2015 };
            var result = ModelValidHelper.Validate(car);
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void VinMinValueValidate()
        {
            var car = new Car { Yop = 2014,Vin = "2015ase" };
            var result = ModelValidHelper.Validate(car);
            Assert.AreEqual("Vin powinien mieć conajmniej 10 znaków", result[0].ErrorMessage);
        }
        [TestMethod]
        public void VinConfirmValidate()
        {
            var car = new Car { Yop = 2014, Vin = "2015aseasfasfsdafdsfs" };
            var result = ModelValidHelper.Validate(car);
            Assert.AreEqual(0, result.Count);
        }
        [TestMethod]
        public void CarOwnerOptionalValidate()
        {
            var car = new Car { Yop = 2014, Vin = "2015aseasfasfsdafdsfs",ArtId = null};
            var result = ModelValidHelper.Validate(car);
            Assert.AreEqual(0, result.Count);
        }

    }
}
