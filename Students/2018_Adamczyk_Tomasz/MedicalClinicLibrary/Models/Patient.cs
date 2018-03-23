using MedicalClinic.Enums;
using MedicalClinic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MedicalClinic.Models
{
    public class Patient : IPatient
    {
        public Patient(String firstName, String lastName, String pesel, Int32 age, Genders sex)
        {
            if (!NameIsValid(firstName))
            {
                throw new Exception("First name is invalid.");
            }
            if (!NameIsValid(lastName))
            {
                throw new Exception("Last name is invalid.");
            }
            if (!PESELIsValid(pesel))
            {
                throw new Exception("PESEL is invalid.");
            }
            if (!AgeIsValid(age))
            {
                throw new Exception("Age is negative or greater or equal than 150 years.");
            }
            FirstName = firstName;
            LastName = lastName;
            PESEL = pesel;
            Age = age;
            Sex = sex;
            Visits = new List<IVisit>();
        }

        public Patient()
        {
        }

        private static bool NameIsValid(String input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (Regex.IsMatch(input, @"^[A-ZĆŁŚŹŻ][a-ząćęłńóśźż]{2,39}$"))
                return true;
            else
                return false;
        }

        private static bool PESELIsValid(String input)
        {
            if (string.IsNullOrEmpty(input)) return false;
            if (Regex.IsMatch(input, @"^[0-9]{11}$"))
                return true;
            else
                return false;
        }

        private static bool AgeIsValid(Int32 input)
        {
            if (input > 0 && input < 150)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            var patient = obj as Patient;
            return patient != null &&
                   FirstName == patient.FirstName &&
                   LastName == patient.LastName &&
                   PESEL == patient.PESEL;
        }

        public String FullName => FirstName + " " + LastName;
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String PESEL { get; set; }
        public Int32 Age { get; set; }
        public Genders Sex { get; set; }
        public List<IVisit> Visits { get; set; }
    }
}
