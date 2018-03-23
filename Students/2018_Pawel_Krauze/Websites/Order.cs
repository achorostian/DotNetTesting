using System;
namespace Websites
{
    public interface IServiceOrder
    {
        int Id { get; }
        string Name { get; }
        IServiceWebsite Website { get; }
        Boolean AddWebsite(IServiceWebsite website);
        void RemoveWebsite();
    }
    public class Order : IServiceOrder
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public IServiceWebsite Website { get; private set; }

        public Order(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Boolean AddWebsite(IServiceWebsite website)
        {
            if (website == null)
                return false;
            Website = website;
            return true;
        }

        public void RemoveWebsite()
        {
            Website = null;
        }
    }
}
