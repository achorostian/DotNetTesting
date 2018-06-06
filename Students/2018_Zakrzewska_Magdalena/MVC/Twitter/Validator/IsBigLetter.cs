using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.Validator
{
    public class IsBigLetter : ValidationAttribute
    {
        public string Word { get; private set; }

        public IsBigLetter()
        {
            Word = null;
        }
        public IsBigLetter(string word)
        {
            Word = word;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string word;
            var errorMessage = validationContext.DisplayName == null ? "Nieporpawna wartość" : FormatErrorMessage(validationContext.DisplayName);
            if (value == null)
                return ValidationResult.Success;
            if (value is string)
                word = value.ToString();
            else
                return new ValidationResult("Typ pola to string");
            
            return !(char.IsUpper(word[0])) ? new ValidationResult("Podane słowo powinno rozpoczynać się od wielkiej litery") : ValidationResult.Success;
        }
    }
}