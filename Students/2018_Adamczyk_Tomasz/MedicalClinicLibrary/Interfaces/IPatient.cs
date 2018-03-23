using MedicalClinic.Enums;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Interfaces
{
    public interface IPatient
    {
        String FirstName { get; set; }

        String LastName { get; set; }

        String PESEL { get; set; }

        Int32 Age { get; set; }

        Genders Sex { get; set; }

        List<IVisit> Visits { get; set; }
    }
}
