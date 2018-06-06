using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalMVVM.ViewModels;
using MinimalMVVM.Services;
using System.Linq;
using Moq;

namespace MinimalMVVMTests
{
    [TestClass]
    public class PresenterTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            String testText = "text";
            var conversionService = new Mock<IUpperCaseConverterService>();
            conversionService.Setup(a => a.Convert(testText)).Returns(testText + "I was mocked");
            Presenter presenter = new Presenter(conversionService.Object, testText);
            presenter.SomeText = testText;
            
            presenter.ConvertText();

            Assert.AreEqual(string.Empty, presenter.SomeText);
            Assert.AreEqual(testText + "I was mocked", presenter.History.FirstOrDefault());
        }

        [TestMethod]
        public void TestMethod2()
        {
            var conversionService = new Mock<IUpperCaseConverterService>().Object;
            String testText = "text";
            Presenter presenter = new Presenter(conversionService, testText);
            var method = presenter.ConvertTextCommand;

            method.Execute(null);

            Assert.AreEqual(presenter.SomeText, string.Empty);
        }
    }
}
