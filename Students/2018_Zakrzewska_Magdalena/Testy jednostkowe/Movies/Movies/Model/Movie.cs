using System;
namespace Movies.Model
{
    public interface iMovie
    {
        string Title { get; }
        int Year { get; }
        string getDescription();
    }

    public class Movie : iMovie
    {
        public string Title { get; private set; }
        public int Year { get; private set; }

        public Movie(string title, int year)
        {
            Title = title;
            Year = year;
        }

        public string getDescription()
        {
            return $"Title : {Title}, Production Year: {Year}";
        }
    }
}
