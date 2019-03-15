using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Service
{
    public interface ITweetContex
    {
        IQueryable<Tweet> Tweets { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        Tweet FindTweetById(int id);
        T Delete<T>(T entity) where T : class;
       
    }
}
