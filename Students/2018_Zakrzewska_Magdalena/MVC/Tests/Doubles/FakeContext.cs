using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;
using Twitter.Service;

namespace testyyyy.Tests.Doubles
{
    public class FakeContext : ITweetContex
    {
       private readonly SetMap _map = new SetMap();

        public IQueryable<Tweet> Tweets
        {
            get { return _map.Get<Tweet>().AsQueryable(); }
            set { _map.Use<Tweet>(value); }
        }

        public bool ChangesSaved { get; set; }

        public int SaveChanges()
        {
            ChangesSaved = true;
            return 0;
        }

        public T Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);
            return entity;
        }

        public Tweet FindTweetById(int id)
        {
            try
            {
                var item = (from c in this.Tweets
                            where c.TweetId == id
                            select c).First();
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }
    }
}
