using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using dotNet.Models.User;
using dotNet.Validator;


namespace dotNet.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        [RangeUntilCurrentYear(1900, ErrorMessage = "Auto nie może być starsze niż {1} rok i nowsze niż obecny rok.")]
        [Display(Name = "Rok produkcji")]
        public int Yop { get; set; }
        [MinLength(10,ErrorMessage = "Vin powinien mieć conajmniej {1} znaków")]
        public string Vin { get; set; }
        [Display(Name = "Artysta")]
        public int? ArtId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}