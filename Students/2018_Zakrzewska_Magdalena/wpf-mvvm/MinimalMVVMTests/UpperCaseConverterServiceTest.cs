using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinimalMVVM.Services;

namespace MinimalMVVMTests
{
    [TestClass]
    public class UpperCaseConverterServiceTest
    {
        [TestMethod]
        public void TestMethod3()
        {
            IUpperCaseConverterService service = new UpperCaseConverterService();

            string before = "before";

            string after = service.Convert(before);

            Assert.AreEqual(before.ToUpper(), after);
        }
    }
}
