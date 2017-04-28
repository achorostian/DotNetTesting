using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using dotNet.Models.Main;
using dotNet.Models.User;

namespace dotNet.Models
{
    public class Song
    {
        public int SongId { get; set; }
        [Display(Name = "Tytuł")]
        public string Tittle { get; set; }
        public string Description { get; set; }
        [Display(Name = "Artysta")]
        public int ArtId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}