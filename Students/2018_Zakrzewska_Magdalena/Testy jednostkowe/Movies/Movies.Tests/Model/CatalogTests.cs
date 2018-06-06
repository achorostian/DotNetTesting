using Movies.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Movies.Tests.Model
{
    [TestClass]
    public class CatalogTests : BaseTests
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
        public void Director_WithCleanFilmography_AfterRemoval()
        {
            GenerateDefaultCatalog();

            catalog.removeDirector(director);

            Assert.IsTrue(catalog.isEmpty(), "Catalog is not empty.");
        }

        [TestMethod]
        [TestCategory("movie")]
        public void Director_WithValidFilmography_AfterMovieRemoval()
        {
            Movie movie = new Movie("to remove", 2010);
            director.addMovie(movie);
            GenerateDefaultCatalog();

            catalog.getDirectorByLastName("Director")
                   .removeMovieByTitle("testMovie");

            bool actual = catalog.getDirectorByLastName("Director").m_movies.Contains(movie);

            Assert.IsFalse(actual, "Movie was not removed.");
        }

        [TestMethod]
        [TestCategory("director")]
        public void DirectorCorrect_When_SearchByLastName()
        {
            GenerateDirectors(3);
            Director expected = new Director("test", "director5");
            catalog.addDirector(expected);

            Director actual = (Director) catalog.getDirectorByLastName("director5");

            Assert.AreSame(expected, actual, "Incorrect director found.");
        }
    }
}
