using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotNet.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Song> Songs { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}