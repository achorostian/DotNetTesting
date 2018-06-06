using System;
using System.Collections.Generic;

namespace Movies.Model
{
    public interface iDirector
    {
        string m_first_name { get; }
        string m_last_name { get; }
        List<iMovie> m_movies { get; }

        List<iMovie> getMoviesByYear(int year);
        void removeMovieByTitle(string title);
        string getDirector();
        void addMovie(iMovie movie);
        void addMovies(List<iMovie> movies);
        void removeMovie(iMovie movie);

    }

    public class Director : iDirector
    {
        public string m_first_name { get; private set; }
        public string m_last_name { get; private set; }
        public List<iMovie> m_movies { get; private set; }

        public Director(string first_name, string last_name)
        {
            m_first_name = first_name;
            m_last_name = last_name;
            m_movies = new List<iMovie>();
        }

        public List<iMovie> getMoviesByYear(int year)
        {
            return m_movies.FindAll((iMovie obj) => obj.Year.Equals(year));
        }

        public void removeMovieByTitle(string title)
        {
            m_movies.RemoveAll((iMovie obj) => obj.Title.ToUpper().Equals(title.ToUpper()));
        }

        public string getDirector()
        {
            return $"{m_first_name} {m_last_name}";
        }

        public void addMovie(iMovie movie)
        {
            m_movies.Add(movie);
        }

        public void addMovies(List<iMovie> movies)
        {
            m_movies.AddRange(movies);
        }

        public void removeMovie(iMovie movie)
        {
            m_movies.Remove(movie);
        }
    }
}
