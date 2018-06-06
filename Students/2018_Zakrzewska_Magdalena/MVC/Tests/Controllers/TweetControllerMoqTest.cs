using System;
using System.Web.Mvc;
using Twitter.Controllers;
using Twitter.Models;
using Twitter.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace testyyyy.Tests.Controllers
{
    [TestClass]
    public class TweetControllerMoqTest
    {

        [TestMethod]
        public void TestDetailsValue()
        {
            var tweet =
                new Tweet
                {
                    TweetId = 1,
                    Title = "Title",
                    Description = "ansmdkesndh",

                };
            var context = new Mock<ITweetContex>();
            context.Setup(a => a.FindTweetById(1)).Returns(tweet);
            var tweetsController = new TweetsController(context.Object);
            var result = (ViewResult)tweetsController.Details(1);
            Assert.AreEqual("Details", result.ViewName);
        }

        
        [TestMethod]
        public void TestDeletePrepareTweet()
        {

            var tweet = new Tweet
            {
                TweetId = 4,
                Title = "Title",
                Description = "ansmdkesndh",

            };
            var context = new Mock<ITweetContex>();
            context.Setup(a => a.FindTweetById(4)).Returns(tweet);
            var tweetsController = new TweetsController(context.Object);
            var result = (ViewResult)tweetsController.Delete(4);
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void TestEditView()
        {
            var tweet =
              new Tweet
              {
                  TweetId = 4,
                  Title = "Title",
                  Description = "ansmdkesndh",

              };
            var context = new Mock<ITweetContex>();
            context.Setup(a => a.FindTweetById(4)).Returns(tweet);
            var controller = new TweetsController(context.Object);
            var result = controller.Edit(4) as ViewResult;
            var data = (Tweet)result.Model;
            Assert.IsTrue("Edit" == result.ViewName && "Title" == data.Title);
        }
    }
}
