using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Websites;
using Websites.Fakes;

namespace WebsitesTests
{
    [TestClass]
    public class UserTests
    {
        User user;

        [TestInitialize]
        public void TestInitialize()
        {
            user = new User("user", "password1234");
        }

        [TestMethod]
        public void ListWebsites_ReturnsEmptyString_WhenWithoutWebsites()
        {
            string result = user.ListWebsites();

            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void ListWebsites_ReturnStringList_WhenWithWebsites()
        {
            var website = new StubIServiceWebsite()
            {
                DomainGet = () => { return "test.com"; },
            };
            user.AddWebsite(website);
            string result = user.ListWebsites();

            StringAssert.Contains(result, "test.com");
        }

        [TestMethod]
        public void ShowWebsite_ReturnWebsiteInformation_WhenProperIndex()
        {
            var website = new StubIServiceWebsite()
            {
                DomainGet = () => { return "test.com"; },
            };
            user.AddWebsite(website);
            string result = user.ShowWebsite(0);

            StringAssert.Contains(result, "test.com");
        }

        [TestMethod]
        public void ShowWebsite_ReturnErrorMsg_WhenNoProperIndex()
        {
            string result = user.ShowWebsite(0);

            StringAssert.Contains(result, "Website for this user does not exist");
        }

        [TestMethod]
        public void DeleteWebsite_RemoveWebsite_WhenProperIndex()
        {
            var website = new StubIServiceWebsite()
            {
                DomainGet = () => { return "test.com"; },
            };
            user.AddWebsite(website);
            user.DeleteWebsite(0);

            Assert.AreEqual(0, user.Websites.Count);
        }

        [TestMethod]
        public void DeleteWebsite_ReturnTrue_WhenProperIndex()
        {
            var website = new StubIServiceWebsite()
            {
                DomainGet = () => { return "test.com"; },
            };
            user.AddWebsite(website);
            bool result = user.DeleteWebsite(0);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteWebsite_ReturnFalse_WhenProperIndex()
        {
            bool result = user.DeleteWebsite(0);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteWebsite_DontRemoveWebsite_WhenNoProperIndex()
        {
            var website = new StubIServiceWebsite()
            {
                DomainGet = () => { return "test.com"; },
            };
            user.AddWebsite(website);
            user.DeleteWebsite(10);

            Assert.AreEqual("test.com", user.Websites[0].Domain);
        }

        [TestMethod]
        public void AddWebsite_ReturnFalse_WhenNullArg()
        {
            bool result = user.AddWebsite(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddWebsite_AddWebsite_WhenWebsiteArg()
        {
            var website = new StubIServiceWebsite()
            {
                DomainGet = () => { return "test.com"; },
            };
            user.AddWebsite(website);

            Assert.AreEqual("test.com", user.Websites[0].Domain);
        }

        [TestMethod]
        public void AddWebsite_ReturnTrue_WhenWebsiteArg()
        {
            var website = new StubIServiceWebsite()
            {
                DomainGet = () => { return "test.com"; },
            };
            bool result = user.AddWebsite(website);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteAllWebsites_RemoveAllUserWebsites()
        {
            for (int i = 0; i < 10; i++)
                user.AddWebsite(new StubIServiceWebsite());

            user.DeleteAllWebsites();
            Assert.AreEqual(0, user.Websites.Count);
        }


        [TestCleanup]
        public void TestCleanup()
        {
            user = null;
        }
    }
}
