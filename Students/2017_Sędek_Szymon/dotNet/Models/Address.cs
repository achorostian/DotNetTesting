namespace Gym.Models
{
    public class Address
    {
        
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string HouseNumber { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}