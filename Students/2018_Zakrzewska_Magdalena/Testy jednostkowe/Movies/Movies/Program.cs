using System;
using Movies.Controller;
using Movies.Model;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
         {
            Catalog catalog = new Catalog();
            CatalogController m_CatalogController = new CatalogController();

            Director spielberg = new Director("Steven", "Spielberg");
            Movie double_dare = new Movie("Double Dare", 2004);
            Movie transformers = new Movie("Transformers", 2007);
            spielberg.addMovie(double_dare);
            spielberg.addMovie(transformers);

            Director adamson = new Director("Andrew","Adamson");
            Movie shrek3 = new Movie("Shrek the Third", 2007);
            adamson.addMovie(shrek3);

            catalog.addDirector(spielberg);
            catalog.addDirector(adamson);

            m_CatalogController.PrintMoviesDirectedInYear(catalog, 2007);
        }
    }
}
