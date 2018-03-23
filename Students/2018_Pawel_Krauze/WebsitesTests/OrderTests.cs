using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Websites;
using Websites.Fakes;

namespace WebsitesTests
{
    [TestClass]
    public class OrderTests
    {
        Order order;

        [TestInitialize]
        public void TestInitialize()
        {
            order = new Order(1, "test");
        }

        [TestMethod]
        public void AddWebsite_DontAddWebsite_WhenNullArg()
        {
            order.AddWebsite(null);

            Assert.IsNull(order.Website);
        }

        [TestMethod]
        public void AddWebsite_ReturnFalse_WhenNullArg()
        {
            bool result = order.AddWebsite(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddWebsite_AddWebsite_WhenWebsiteArg()
        {
            var website = new StubIServiceWebsite()
            {
                DomainGet = () => { return "test.com"; },
            };
            order.AddWebsite(website);

            Assert.AreEqual("test.com", order.Website.Domain);
        }

        [TestMethod]
        public void AddWebsite_ReturnTrue_WhenWebsiteArg()
        {
            var website = new StubIServiceWebsite()
            {
                DomainGet = () => { return "test.com"; },
            };
            bool result = order.AddWebsite(website);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveWebsite_RemoveWebsite()
        {
            var website = new StubIServiceWebsite();
            order.AddWebsite(website);
            order.RemoveWebsite();

            Assert.IsNull(order.Website);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            order = null;
        }
    }
}
