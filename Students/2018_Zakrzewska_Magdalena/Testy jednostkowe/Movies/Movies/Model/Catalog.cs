using System;
using System.Collections.Generic;

namespace Movies.Model
{
    public interface iCatalog
    {
        List<iDirector> m_directors { get; }

        void addDirector(iDirector director);
        iDirector getDirectorByLastName(String lastName);
        void removeDirector(iDirector director);
        bool isEmpty();
    }

    public class Catalog : iCatalog
    {
        public List<iDirector> m_directors { get; private set; }

        public Catalog()
        {
            m_directors = new List<iDirector>();
        }

        public iDirector getDirectorByLastName(String lastName)
        {
            return m_directors.Find((iDirector obj) => obj.m_last_name.Equals(lastName));
        }

        public void addDirector(iDirector director)
        {
            m_directors.Add(director);
        }

        public void removeDirector(iDirector director)
        {
            if (m_directors.Exists((obj) => obj.Equals(director)))
            {
                m_directors.Remove(director);
                return;
            }

            throw new KeyNotFoundException();
        }

        public bool isEmpty()
        {
            return m_directors.Count.Equals(0);
        }
    }
}
