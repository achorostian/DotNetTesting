using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Websites
{
    public interface IServiceWebsite
    {
        IServiceUser Owner { get; }
        String Domain { get; }
        String Description { get; }
        int PageAuthority { get; }
        int DomainAuthority { get; }
        List<IServiceOrder> Orders { get; }
        Boolean AddOrder(IServiceOrder order);
        Boolean RemoveOrder(IServiceOrder order);
        void ChangeDomainAuthority(int value);
        void ChangePageAuthority(int value);
        string OrdersNameList();
    }
    public class Website : IServiceWebsite
    {
        public String Domain { get; private set; }
        public String Description { get; private set; }
        public int PageAuthority { get; private set; }
        public int DomainAuthority { get; private set; }
        public List<IServiceOrder> Orders { get; private set; }

        public IServiceUser Owner { get; private set; }

        public Website(String domain, String description, int pageRank, int pageAuthority, int domainAuthority)
        {
            Domain = domain;
            Description = description;
            PageAuthority = pageAuthority;
            DomainAuthority = domainAuthority;
            Orders = new List<IServiceOrder>();
        }

        public Boolean AddOrder(IServiceOrder order)
        {
            if (order != null && !OrderExists(order))
            {
                Orders.Add(order);
                order.AddWebsite(this);
                return true;
            }
            return false;
        }

        public Boolean RemoveOrder(IServiceOrder order)
        {
            if (order != null && OrderExists(order))
            {
                Orders.Remove(order);
                order.RemoveWebsite();
                return true;
            }
            return false;
        }

        public Boolean OrderExists(IServiceOrder order)
        {
            IServiceOrder searchedOrder = Orders.Find(o => order.Name == o.Name);
            if (searchedOrder != null)
                return true;
            return false;
        }

        public void ChangeDomainAuthority(int value)
        {
            if (value == 0)
                throw new ArgumentOutOfRangeException("Value", value, "cannot be equal 0");
            if (DomainAuthority + value > 100)
                throw new ArgumentOutOfRangeException("Domain Authority cannot be bigger than 100");
            DomainAuthority += value;
        }

        public void ChangePageAuthority(int value)
        {
            if (value == 0)
                throw new ArgumentOutOfRangeException("Value", value, "cannot be equal 0");
            if (PageAuthority + value > 100)
                throw new ArgumentOutOfRangeException("Page Authority cannot be bigger than 100");
            PageAuthority += value;
        }

        public string OrdersNameList()
        {
            string list = "";

            if (Orders.Count == 0)
                return list;
            else
            {
                foreach (IServiceOrder o in Orders)
                    list += $"{o.Name} ";

                return list;
            }
        }
    }
}
