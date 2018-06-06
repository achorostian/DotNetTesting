using Movies.Model;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Movies.Tests.Model
{
    [TestClass]
    public class DirectorTests : BaseTests
    {
        [TestInitialize]
        public void SetUp()
        {
            director = new Director("Test", "Director");
            catalog = new Catalog();
            catalog.addDirector(director);
        }

        [TestMethod]
        [TestCategory("director")]
        public void Movie_WhenSearchedByYear_ReturnedCorrectly()
        {
            GenerateDefaultCatalog();

            List<iMovie> expected = new List<iMovie>();
            expected.Add(new Movie("testMovie", 2001));
            expected.Add(new Movie("testMovie2", 2001));

            List<iMovie> actual = catalog.getDirectorByLastName("Director").getMoviesByYear(2001);

            Assert.AreSame(actual, expected, "Search movies results incorrect.");
        }
    }
}
