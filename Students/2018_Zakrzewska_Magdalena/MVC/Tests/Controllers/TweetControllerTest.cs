using System;
using System.Linq;
using System.Web.Mvc;
using Twitter.Controllers;
using Twitter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using testyyyy.Tests.Doubles;

namespace testyyyy.Tests.Controllers
{
    [TestClass]
    public class TweetControllerTest
    {

  
        [TestMethod]
        public void TestDetailsNull()
        {
            var tweetsController = new TweetsController();
            var result = (HttpStatusCodeResult)tweetsController.Details(null);
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public void TestDetailsValue()
        {
            var context = new FakeContext
            {
                Tweets = new[]
                {
                     new Tweet{
                         TweetId = 1,
                Title = "Title",
                Description = "ansmdkesndh",

                   }
                }.AsQueryable()
            };
            var tweetsController = new TweetsController(context);
            var result = (ViewResult)tweetsController.Details(1);
            Assert.AreEqual("Details", result.ViewName);


        }
        [TestMethod]
        public void TestDeletePrepareTweet()
        {
            var context = new FakeContext
            {
                Tweets = new[]
                 {
                     new Tweet{
                         TweetId = 1,
                Title = "Title",
                Description = "ansmdkesndh",

                   }
                }.AsQueryable()
            };
            var tweetsController = new TweetsController(context);
            var result = (ViewResult)tweetsController.Delete(1);
            Assert.AreEqual("Delete", result.ViewName);
        }
        [TestMethod]
        public void TestDeleteConfirmTweet()
        {
            var context = new FakeContext
            {
                Tweets = new[]
                 {
                     new Tweet{
                         TweetId = 1,
                Title = "Title",
                Description = "ansmdkesndh",

                   }
                }.AsQueryable()
            };
            var tweetsController = new TweetsController(context);
            var result = (RedirectToRouteResult)tweetsController.DeleteConfirmed(1);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void TestEditTweet()
        {
            var context = new FakeContext
            {
                Tweets = new[]
                 {
                     new Tweet{
                         TweetId = 1,
                Title = "Title",
                Description = "ansmdkesndh"

                   }
                }.AsQueryable()
            };
            var tweetsController = new TweetsController(context);
            var result = tweetsController.Edit(2);
            Assert.AreEqual(typeof(HttpNotFoundResult), result.GetType());
        }
    }
}

