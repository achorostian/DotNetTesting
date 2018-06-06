using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twitter.Models.Main
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Year { get; set; }
        
     
    }
}