using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Websites;
using Websites.Fakes;
using System.Collections.Generic;

namespace WebsitesTests
{
    [TestClass]
    public class WebsiteTests
    {
        Website website;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            website = new Website("test.com", "test description", 4, 20, 20);
        }

        [DeploymentItem("Websites.WebsitesTests\\OrderData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", 
                    "|DataDirectory|\\OrderData.csv", "OrderData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void AddOrder_AddOrder_WhenOrderArg()
        {
            int id = Int32.Parse(TestContext.DataRow["id"].ToString());
            string name = TestContext.DataRow["name"].ToString();
            Order order = new Order(id, name);
            bool result = website.AddOrder(order);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddOrder_ReturnFalse_WhenOrderExists()
        {
            Order order = new Order(1, "test");
            website.AddOrder(order);
            bool result = website.AddOrder(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddOrder_ReturnFalse_WhenNullArg()
        {
            bool result = website.AddOrder(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveOrder_ReturnFalse_WhenNullArg()
        {
            bool result = website.RemoveOrder(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveOrder_ReturnTrue_WhenOrderExists()
        {
            var order = new StubIServiceOrder()
            {
                IdGet = () => { return 1; },
                NameGet = () => { return "test"; }
            };
            website.AddOrder(order);
            bool result = website.RemoveOrder(order);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveOrder_ReturnFalse_WhenOrderNoExists()
        {
            var order = new StubIServiceOrder()
            {
                IdGet = () => { return 1; },
                NameGet = () => { return "test"; }
            };
            bool result = website.RemoveOrder(order);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OrdersExists_ReturnTrue_WhenOrderExist()
        {
            var order = new StubIServiceOrder()
            {
                IdGet = () => { return 1; },
                NameGet = () => { return "test"; }
            };
            website.AddOrder(order);
            Assert.IsTrue(website.OrderExists(order));
        }

        [TestMethod]
        public void OrdersExists_ReturnFalse_WhenOrderNoExist()
        {
            var order = new StubIServiceOrder()
            {
                IdGet = () => { return 1; },
                NameGet = () => { return "test"; }
            };
            Assert.IsFalse(website.OrderExists(order));
        }

        [TestMethod]
        public void ChangeDomainAuthority_ThrowExpection_WhenValueIs0()
        {
            Exception expectedExcetpion = null;

            try
            {
                website.ChangeDomainAuthority(0);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangeDomainAuthority_ThrowExpection_WhenSumValueIsBiggerThan100()
        {
            website = new Website("tak.com", "fajna", 20, 20, 99);
            website.ChangeDomainAuthority(10);
            Assert.AreEqual(99, website.DomainAuthority);
        }

        [TestMethod]
        public void ChangeDomainAuthority_ChangesDomainAuthority_WhenPostiveValue()
        {
            website.ChangeDomainAuthority(10);
            Assert.AreEqual(30, website.DomainAuthority);
        }

        [TestMethod]
        public void ChangeDomainAuthority_ChangeDomainAuthority_WhenNegativeValue()
        {
            website.ChangeDomainAuthority(-10);
            Assert.AreEqual(10, website.DomainAuthority);
        }

        [TestMethod]
        public void ChangePageAuthority_ThrowExpection_WhenValueIs0()
        {
            Exception expectedExcetpion = null;

            try
            {
                website.ChangePageAuthority(0);
            }
            catch (Exception ex)
            {
                expectedExcetpion = ex;
            }

            Assert.IsNotNull(expectedExcetpion);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ChangePageAuthority_ThrowExpection_WhenSumValueIsBiggerThan100()
        {
            website = new Website("tak.com", "fajna", 20, 99, 99);
            website.ChangePageAuthority(10);
            Assert.AreEqual(99, website.PageAuthority);
        }

        [TestMethod]
        public void ChangePageAuthority_ChangeDomainAuthority_WhenPostiveValue()
        {
            website.ChangePageAuthority(10);
            Assert.AreEqual(30, website.PageAuthority);
        }

        [TestMethod]
        public void ChangePageAuthority_ChangeDomainAuthority_WhenNegativeValue()
        {
            website.ChangePageAuthority(-10);
            Assert.AreEqual(10, website.PageAuthority);
        }

        [TestMethod]
        public void OrdersNameList_ReturnEmptyString_WhenNoOrders()
        {
            string result = website.OrdersNameList();
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void OrdersNameList_ReturnString_WhenOrders()
        {
            var order = new StubIServiceOrder()
            {
                IdGet = () => { return 1; },
                NameGet = () => { return "test"; }
            };
            website.AddOrder(order);
            string result = website.OrdersNameList();
            StringAssert.Contains(result, "test");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            website = null;
        }
    }
}
