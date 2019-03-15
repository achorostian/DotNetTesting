using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Twitter.Models;
using Twitter.Models.Main;

namespace Twitter.Controllers
{
    [Authorize(Roles = "Member,Student,Admin")]
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tweets
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Comment> comments = db.Comments.ToList();
            List<Comment> filteredComments = new List<Comment>();

            foreach (var comment in comments)
            {
                if (comment.TweetId == id)
                {
                    filteredComments.Add(comment);
                }
            }
            return View(filteredComments.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.TweetId = new SelectList(db.Tweets, "TweetId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Content,TweetId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index", "Tweets", null);
            }

            ViewBag.TweetId = new SelectList(db.Tweets, "TweetId", "Title", comment.TweetId);
            return View(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}