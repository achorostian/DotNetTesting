using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gym.Models
{
    public class ListUserViewModel
    {
        public string Email { get; set; }
        public string Rola { get; set; }
    }
}