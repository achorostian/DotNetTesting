using System.Linq;
using Twitter.Models.Ebay;

namespace Twitter.Service
{
    public interface IEbayContext
    {
        IQueryable<Items> Items { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        Items FindEbayById(int id);
        T Delete<T>(T entity) where T : class;
        double Average();
    }
}
