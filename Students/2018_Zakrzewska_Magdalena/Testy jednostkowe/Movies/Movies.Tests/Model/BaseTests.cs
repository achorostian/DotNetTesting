using Movies.Model;
using System.Collections.Generic;

namespace Movies.Tests
{
    public class BaseTests
    {
        protected Catalog catalog;
        protected Director director;

        protected void GenerateDefaultCatalog()
        {
            List<iMovie> list = new List<iMovie>();
            list.Add(new Movie("testMovie", 2001));
            list.Add(new Movie("testMovie2", 2001));

            director.addMovies(list);
            catalog.addDirector(director);
            catalog.removeDirector(director);
        }

        protected void GenerateDirectors(int j)
        {
            for (int i = 1; i < j; i++)
            {
                catalog.addDirector(new Director("test", $"director{i}"));
            }
        }
    }
}
