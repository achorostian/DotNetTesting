﻿using System.ComponentModel.DataAnnotations;
using Twitter.Validator;

namespace Twitter.Models.User
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj")]
        public bool RememberMe { get; set; }
    }
    //required nad kazda klasa?
    public class RegisterViewModel
    {
        //na czas testow wywalilem required oraz ograniczylem walidacje hasla i ilosc znakow

        [IsBigLetter]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [IsBigLetter]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Required]
        [IsGender]
        [Display(Name = "Płeć (k lub m)")]
        public string Gender { get; set; }

        
        [Display(Name = "Rok urodzenia")]
        public string Year { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Podane {0} musi mieć conajmniej {2} znaków", MinimumLength = 2)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Podane hasła różnią się")]
        public string ConfirmPassword { get; set; }

      
    }
}