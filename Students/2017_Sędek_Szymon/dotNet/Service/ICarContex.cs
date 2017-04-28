using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet.Models;

namespace dotNet.Service
{
    public interface ICarContex
    {
        IQueryable<Car> Cars { get; }
        IQueryable<Artist> Artists { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        Car FindCarById(int id);
        Artist FindArtistById(int id);
        T Delete<T>(T entity) where T : class;
       
    }
}
