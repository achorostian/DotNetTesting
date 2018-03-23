using System.Collections.Generic;
using System;

namespace Websites
{
    public interface IServiceUser
    {
        string Username { get; }
        string Password { get; }
        List<IServiceWebsite> Websites { get; }
        string ListWebsites();
        string ShowWebsite(int id);
        Boolean DeleteWebsite(int i);
        void DeleteAllWebsites();
        Boolean AddWebsite(IServiceWebsite website);
    }

    public class User : IServiceUser
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public List<IServiceWebsite> Websites { get; private set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Websites = new List<IServiceWebsite>();
        }

        public string ListWebsites()
        {
            string list = "";
            if (Websites.Count == 0)
                return list;
            else
            {
                foreach (IServiceWebsite w in Websites)
                    list += $"Domain: {w.Domain}, Description: {w.Description}, PA: {w.PageAuthority}, DA: {w.DomainAuthority}\n";
                return list;
            }
        }

        public string ShowWebsite(int index)
        {
            if (WebsiteExists(index))
            {
                IServiceWebsite w = Websites[index];
                return $"Domain: {w.Domain}, Description: {w.Description}, PA: {w.PageAuthority}, DA: {w.DomainAuthority}";
            }
            else
                return "Website for this user does not exist";
        }

        public Boolean DeleteWebsite(int index)
        {
            if (WebsiteExists(index))
            {
                Websites.RemoveAt(index);
                return true;
            }
            else
                return false;
        }

        public Boolean AddWebsite(IServiceWebsite website)
        {
            if (website == null && Websites.Find(w => website.Domain == w.Domain) == null)
                return false;
            Websites.Add(website);
            return true;
        }

        public void DeleteAllWebsites()
        {
            Websites = new List<IServiceWebsite>();
        }

        private Boolean WebsiteExists(int index)
        {
            if (index < Websites.Count && index >= 0)
                return true;
            return false;
        }
    }
}