using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using dotNet.Models;

namespace dotNet.Service
{
    public class CarContext: DbContext,ICarContex
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Car> Cars { get; set; }

        IQueryable<Car> ICarContex.Cars => Cars;

        IQueryable<Artist> ICarContex.Artists => Artists;

        int ICarContex.SaveChanges()
        {
            return SaveChanges();
        }

        T ICarContex.Add<T>(T entity)
        {
            return Set<T>().Add(entity);
        }

        Car ICarContex.FindCarById(int id)
        {
            return Set<Car>().Find(id);
        }

        Artist ICarContex.FindArtistById(int id)
        {
            return Set<Artist>().Find(id);
        }


        T ICarContex.Delete<T>(T entity)
        {
            return Set<T>().Remove(entity);
        }
    }
}