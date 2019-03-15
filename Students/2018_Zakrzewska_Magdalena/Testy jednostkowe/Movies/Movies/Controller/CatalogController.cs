using System;
using Movies.Model;
using System.Collections.Generic;

namespace Movies.Controller
{
    public class CatalogController
    {
        public void PrintMoviesDirectedInYear(iCatalog catalog, int year)
        {
            catalog.m_directors.ForEach((iDirector obj) => 
                                            obj
                                            .getMoviesByYear(year)
                                        .ForEach((iMovie movie) => Console.WriteLine(movie.getDescription())));
        }

        public List<iMovie> getMoviesBetween(iCatalog catalog, int fromYear)
        {
            return getMoviesBetween(catalog, fromYear, DateTime.Now.Year);
        }

        public List<iMovie> getMoviesBetween(iCatalog catalog, int fromYear, int toYear)
        {
            List<iMovie> list = new List<iMovie>();
            catalog.m_directors.ForEach((iDirector obj) => list.AddRange(obj.m_movies.FindAll((iMovie movie) => movie.Year >= fromYear && movie.Year <= toYear)));

            return list;
        }
    }
}
