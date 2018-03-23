using System;

namespace MedicalClinic.Interfaces
{
    public interface IVisit
    {
        IPatient Patient { get; set; }

        DateTime DateOfVisit { get; set; }

        String Description { get; set; }

        Decimal Price { get; set; }
    }
}
