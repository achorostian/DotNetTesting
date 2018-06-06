using System.Data.Entity;
using System.Linq;
using Twitter.Models;

namespace Twitter.Service
{
    public class TweetContext: DbContext,ITweetContex
    {
        public DbSet<Tweet> Tweets { get; set; }

        IQueryable<Tweet> ITweetContex.Tweets => Tweets;

        int ITweetContex.SaveChanges()
        {
            return SaveChanges();
        }

        T ITweetContex.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        Tweet ITweetContex.FindTweetById(int id)
        {
            return Set<Tweet>().Find(id);
        }


        T ITweetContex.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }

        public System.Data.Entity.DbSet<Twitter.Models.Comment> Comments { get; set; }
    }
}