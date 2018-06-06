using System.Data.Entity;
using System.Linq;
using Twitter.Models.Ebay;

namespace Twitter.Service
{
    public class EbayContext: DbContext,IEbayContext
    {
        public DbSet<Items> Items { get; set; }

        IQueryable<Items> IEbayContext.Items => Items;

        int IEbayContext.SaveChanges()
        {
            return SaveChanges();
        }

        T IEbayContext.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        Items IEbayContext.FindEbayById(int id)
        {
            return Set<Items>().Find(id);
        }


        T IEbayContext.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }

        double IEbayContext.Average()
        {
            var items = Set<SellingStatus>().ToList();
            var sum = 0.0;
            var count = 0;
            foreach (var value in items)
            {
                sum += double.Parse(value.currentPrice.ToString().Replace(".",","));
                count += 1;
            }

            return sum / count;
        }

        public DbSet<SellingStatus> sellingStatuses { get; set; }
    }
}