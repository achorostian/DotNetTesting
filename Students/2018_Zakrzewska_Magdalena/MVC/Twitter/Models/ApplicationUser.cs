using Microsoft.AspNet.Identity.EntityFramework;

namespace Gym.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Year { get; set; }
        public virtual Address Address { get; set; }
    }
}