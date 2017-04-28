using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace testyyyy.Tests.Controllers
{
    [TestClass]
    public class CarSeleniumTest
    {
        [TestMethod]
        public void CarDetailsTest()
        {
            IWebDriver driver = new ChromeDriver();
            var nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Cars");
            var element = driver.FindElement(By.Name("details"));
            element.Click();
            var checkTest = driver.FindElement(By.Id("carTittle")).Text;
            Assert.AreEqual("Car Details", checkTest);
            driver.Close();
        }

        [TestMethod]
        public void CarEditTest()
        {
            IWebDriver driver = new ChromeDriver();
            var nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Cars");
            var element = driver.FindElement(By.Name("edit"));
            element.Click();
            var checkTest = driver.FindElement(By.Id("editCar")).Text;
            Assert.AreEqual("Edit", checkTest);
            driver.Close();
        }
        [TestMethod]
        public void CarDeleteTest()
        {
            IWebDriver driver = new ChromeDriver();
            var nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Cars");
            var element = driver.FindElement(By.Name("delete"));
            element.Click();
            var checkTest = driver.FindElement(By.Id("sureDelete")).Text;
            Assert.AreEqual("Are you sure you want to delete this?", checkTest);
            driver.Close();
        }

        [TestMethod]
        public void TestAddCar()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Cars/Create");
            driver.FindElement(By.Id("Model")).Click();
            driver.FindElement(By.Id("Model")).SendKeys("opel");
            driver.FindElement(By.Id("Yop")).Click();
            driver.FindElement(By.Id("Yop")).SendKeys("1988");
            driver.FindElement(By.Id("Vin")).Click();
            driver.FindElement(By.Id("Vin")).SendKeys("msjiemskaoejds");
            driver.FindElement(By.Name("create")).Click();
            string checkTest = driver.FindElement(By.Id("indexCar")).Text;
            Assert.AreEqual("Index", checkTest);
            driver.Close();

        }
        [TestMethod]
        public void TestAddNotValidCar()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Cars/Create");
            driver.FindElement(By.Id("Model")).Click();
            driver.FindElement(By.Id("Model")).SendKeys("opel");
            driver.FindElement(By.Id("Yop")).Click();
            driver.FindElement(By.Id("Yop")).SendKeys("198");
            driver.FindElement(By.Id("Vin")).Click();
            driver.FindElement(By.Id("Vin")).SendKeys("msjiemskaoejds");
            driver.FindElement(By.Name("create")).Click();
            string checkTest = driver.FindElement(By.Id("createCar")).Text;
            Assert.AreEqual("Create", checkTest);
            driver.Close();

        }
    }
}
