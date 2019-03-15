using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Twitter.Models;
using Twitter.Models.Main;
using Twitter.Service;

namespace Twitter.Controllers
{
    public class TweetsController : Controller
    {
        private readonly ITweetContex db;

        // GET: Tweets
        public ActionResult Index()
        {
            return View(db.Tweets.ToList());
        }

        public TweetsController()
        {
            db = new ApplicationDbContext();
        }

        public TweetsController(ITweetContex tweetContext)
        {
            db = tweetContext;
        }

        // GET: Tweets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.FindTweetById(id.Value);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View("Details", tweet);
        }

        // GET: Tweets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tweets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TweetId,Title,Description")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                db.Add<Tweet>(tweet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        // GET: Tweets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id < 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.FindTweetById(id.Value);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View("Edit", tweet);
        }

        // POST: Tweets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TweetId,Title,Description")] Tweet tweet)
        {
            if (ModelState.IsValid)
            {
                Tweet prepareTweet = db.FindTweetById(tweet.TweetId);
                prepareTweet.Title = tweet.Title;
                prepareTweet.Description = tweet.Description;
                prepareTweet.Comments = tweet.Comments;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tweet);
        }

        // GET: Tweets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = db.FindTweetById(id.Value);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View("Delete", tweet);
        }

        // POST: Tweets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = db.FindTweetById(id);
            db.Delete<Tweet>(tweet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
