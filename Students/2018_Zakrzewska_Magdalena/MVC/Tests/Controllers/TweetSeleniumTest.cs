using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace testyyyy.Tests.Controllers
{
    [TestClass]
    public class TweetSeleniumTest
    {
        [TestMethod]
        public void TweetDetailsTest()
        {
            IWebDriver driver = new ChromeDriver();
            var nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Tweets");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var element = driver.FindElement(By.PartialLinkText("Details"));
            element.Click();
            var checkTest = driver.FindElement(By.Id("tweetDetails")).Text;
            Assert.AreEqual("Details", checkTest);
            driver.Close();
        }

        [TestMethod]
        public void TweetEditTest()
        {
            IWebDriver driver = new ChromeDriver();
            var nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Tweets");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var element = driver.FindElement(By.PartialLinkText("Edit"));
            element.Click();
            var checkTest = driver.FindElement(By.Id("editTweet")).Text;
            Assert.AreEqual("Edit", checkTest);
            driver.Close();
        }
        [TestMethod]
        public void TweetDeleteTest()
        {
            IWebDriver driver = new ChromeDriver();
            var nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Tweets");
            var element = driver.FindElement(By.PartialLinkText("Delete"));
            element.Click();
            var checkTest = driver.FindElement(By.Id("sureDelete")).Text;
            Assert.AreEqual("Are you sure you want to delete this?", checkTest);
            driver.Close();
        }

        [TestMethod]
        public void TestAddTweet()
        {
            IWebDriver driver = new InternetExplorerDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Tweets/Create");
            driver.FindElement(By.Id("Title")).Click();
            driver.FindElement(By.Id("Title")).SendKeys("title");
            driver.FindElement(By.Id("Description")).Click();
            driver.FindElement(By.Id("Description")).SendKeys("Description");
            driver.FindElement(By.Id("Create")).Click();
            string checkTest = driver.FindElement(By.Id("indexTweet")).Text;
            Assert.AreEqual("Index", checkTest);
            driver.Close();

        }
        [TestMethod]
        public void TestAddNotValidTweet()
        {
            IWebDriver driver = new InternetExplorerDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:2120/Tweets/Create");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);


            IWebElement title = driver.FindElement(By.Id("Title"));
            IWebElement description = driver.FindElement(By.Id("Description"));
            IWebElement create = driver.FindElement(By.Id("Create"));

            title.Clear();
            title.SendKeys("title");
           
            description.Clear();
            description.SendKeys("Desc");

            create.Click();
            string checkTest = driver.FindElement(By.Id("createTweet")).Text;
            Assert.AreEqual("Create", checkTest);
            driver.Close();

        }
    }
}
