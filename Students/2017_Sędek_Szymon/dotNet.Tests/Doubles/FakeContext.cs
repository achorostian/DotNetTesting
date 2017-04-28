using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNet.Models;
using dotNet.Service;

namespace testyyyy.Tests.Doubles
{
    public class FakeContext : ICarContex
    {
       private readonly SetMap _map = new SetMap();

        public IQueryable<Car> Cars
        {
            get { return _map.Get<Car>().AsQueryable(); }
            set { _map.Use<Car>(value); }
        }

        public IQueryable<Artist> Artists
        {
            get { return _map.Get<Artist>().AsQueryable(); }
            set { _map.Use<Artist>(value); }
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

        public Car FindCarById(int id)
        {
            var item = (from p in this.Cars
                        where p.CarId == id
                          select p).First();

            return item;
        }

        public Artist FindArtistById(int id)
        {
            var item = (from c in this.Artists
                           where c.ArtistId == id
                            select c).First();
            return item;
        }


        public T Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            return entity;
        }
    }
}
