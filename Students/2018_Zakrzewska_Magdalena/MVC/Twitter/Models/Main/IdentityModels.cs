using System.Data.Entity;
using System.Linq;
using Twitter.Service;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models.Main
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>,ITweetContex
    {
        public ApplicationDbContext() : base("Net")
        {
            Database.SetInitializer(new DotNetDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Comment> Comments { get; set; }

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
    }
}