using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dotNet.Validator
{
    public class IsGender : ValidationAttribute
    {
        public string Gender { get; private set; }

        public IsGender()
        {
            Gender = null;
        }
        public IsGender(string gender)
        {
            Gender = gender;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorMessage;
            string gender;
            errorMessage = validationContext.DisplayName == null ? "Płeć nie jest poprawna" : FormatErrorMessage(validationContext.DisplayName);
            if (value == null)
                return ValidationResult.Success;
            if (value is string)
                gender = value.ToString();
            else
            {
                return new ValidationResult("Typ pola płeć to string");
            }
            if (!(gender == "k" || gender == "K" || gender == "m" || gender == "M"))
                return new ValidationResult("Płeć nie jest poprawna");
            return ValidationResult.Success;
        }
    }
}