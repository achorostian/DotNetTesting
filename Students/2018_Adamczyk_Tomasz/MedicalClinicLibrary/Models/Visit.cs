using MedicalClinic.Interfaces;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Models
{
    public class Visit : IVisit
    {
        public Visit(IPatient patient, DateTime dateOfVisit, String description, Decimal price)
        {
            if (!DateOfVisitIsValid(dateOfVisit))
            {
                throw new Exception("Date of visit must be earlier than present time.");
            }
            if (!PriceIsPositive(price))
            {
                throw new Exception("Price cannot be less than 0.");
            }
            Patient = patient;
            DateOfVisit = dateOfVisit;
            Description = description;
            Price = price;
        }

        public Visit()
        {
        }

        private static bool DateOfVisitIsValid(DateTime dateOfVisit)
        {
            if (dateOfVisit <= DateTime.Now)
                return true;
            else
                return false;
        }

        private static bool PriceIsPositive(Decimal price)
        {
            if (price >= 0M)
                return true;
            else
                return false;
        }

        public override bool Equals(object obj)
        {
            var visit = obj as Visit;
            return visit != null &&
                   EqualityComparer<IPatient>.Default.Equals(Patient, visit.Patient) &&
                   DateOfVisit == visit.DateOfVisit &&
                   Description == visit.Description &&
                   Price == visit.Price;
        }

        public IPatient Patient { get; set; }
        public DateTime DateOfVisit { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
    }
}
