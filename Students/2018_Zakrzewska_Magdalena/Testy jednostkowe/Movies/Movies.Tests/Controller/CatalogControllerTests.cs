using System;
using System.Fakes;
using System.Collections.Generic;
using System.Text
using Movies.Controller;
using Movies.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Movies.Tests.Controller
{
    [TestClass]
    class CatalogControllerTests
    {

        public int GetTheCurrentYear()
        {
            return DateTime.Now.Year;
        }

        private Catalog CreateCatalog(Catalog catalog, Movie movie)
        {
            Movie movie2 = new Movie("movie2", 2007);
            Movie movie3 = new Movie("movie3", 2011);
            Director director = new Director("john", "snow");
            director.addMovie(movie);
            director.addMovie(movie2);
            director.addMovie(movie3);
            catalog.addDirector(director);

            return catalog;
        }

        /*    [TestMethod]
            [DataSource ("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                @"Data.csv",
                "Data#csv",
                DataAccessMethod.Random),
                DeploymentItem("Data.csv")]
            [TestCategory("Program")]
            public void ShouldPrintAllResultsFromCSV()
            {
                TestContext.DataRow("FirstName").ToString();
            }*/

        [TestMethod]
        public void MoviesCorrectlyReturned_BetweenDates()
        {
            CatalogController catalogController = new CatalogController();
            Movie expectedMovie = new Movie("expected", 2010);
            Catalog catalog = CreateCatalog(new Catalog(), expectedMovie);
            List<iMovie> expectedMoviesList = new List<iMovie>();
            expectedMoviesList.Add(expectedMovie);

            using (ShimsContext.Create())
            {
                System.Fakes.ShimeDateTime.NowGet =
                    () =>
                    {
                        return new DateTime(2010, 1, 1);
                    };

            }
            List<iMovie> movies = catalogController.getMoviesBetween(catalog, 2008);

            Assert.AreSame(expectedMoviesList, movies, "Movies inconsistent.");
        }
    }
}
