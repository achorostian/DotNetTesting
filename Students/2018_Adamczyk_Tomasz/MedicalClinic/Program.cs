using MedicalClinic.Enums;
using MedicalClinic.Interfaces;
using MedicalClinic.Models;
using System;
using System.Collections.Generic;

namespace MedicalClinic
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicalClinic clinic = new MedicalClinic();
            Console.WriteLine("WELCOME IN OUR MEDICAL CLINIC HISTORY!!!");
            EmptyLine();
            Console.WriteLine($"Patients counter: {clinic.GetPatientsCounter()}");
            Console.WriteLine($"Visits counter: {clinic.GetVisitsCounter()}");
            EmptyLine();
            Console.WriteLine("Add two patients:");
            clinic.AddPatient("Tomasz", "Adamczyk", "94010112345", 24, Genders.Male);
            ShowPatient(clinic, 0);
            clinic.AddPatient("Adam", "Kownacki", "97010112345", 21, Genders.Male);
            ShowPatient(clinic, 1);
            Console.WriteLine($"Patients counter: {clinic.GetPatientsCounter()}");
            Console.WriteLine($"Visits counter: {clinic.GetVisitsCounter()}");
            EmptyLine();
            Console.WriteLine("Add visits:");
            clinic.AddVisit((Patient)clinic.Patients[0], DateTime.Parse("2018-03-20 09:00"), "Flu", 0M);
            clinic.AddVisit((Patient)clinic.Patients[0], DateTime.Parse("2018-01-22 10:30"), "Stomache", 10M);
            clinic.AddVisit((Patient)clinic.Patients[1], DateTime.Parse("2018-03-20 09:15"), "Flu", 0M);
            EmptyLine();
            Console.WriteLine("Patients list of visits:");
            ShowPatientVisits(clinic, 0);
            ShowPatientVisits(clinic, 1);
            Console.WriteLine($"Patients counter: {clinic.GetPatientsCounter()}");
            Console.WriteLine($"Visits counter: {clinic.GetVisitsCounter()}");
            EmptyLine();
            Console.WriteLine("Patients with \'a\' letter in name:");
            var patientsWithLetter_a_InName = clinic.FindPatients("a");
            ShowFindPatientsResults(patientsWithLetter_a_InName);
            Console.WriteLine("Patients with \'94\' numbers in PESEL:");
            var patientsWithNumbers_94_InPESEL = clinic.FindPatients("94");
            ShowFindPatientsResults(patientsWithNumbers_94_InPESEL);
            Console.WriteLine("Patients with \'b\' letter in name:");
            var patientsWithLetter_b_InName = clinic.FindPatients("b");
            ShowFindPatientsResults(patientsWithLetter_b_InName);
            Console.WriteLine("Visits from \'2018-03-20\':");
            var visitFromDate20180320 = clinic.FindVisits("2018-03-20");
            ShowFindVisitsResults(visitFromDate20180320);
            Console.WriteLine("EXIT press any key...");
            Console.ReadKey();
        }

        private static void EmptyLine()
        {
            Console.WriteLine();
        }

        private static void ShowPatient(MedicalClinic clinic, int id)
        {
            Console.WriteLine($"Patient {id + 1}. {clinic.Patients[id].FirstName} {clinic.Patients[id].LastName} - {clinic.Patients[id].PESEL}");
            EmptyLine();
        }

        private static void ShowPatientVisits(MedicalClinic clinic, int id)
        {
            ShowPatient(clinic, id);
            Console.WriteLine("Visits:");
            int i = 1;
            foreach (Visit v in clinic.Patients[id].Visits)
            {
                Console.WriteLine($"{i++}. Date of visit: {v.DateOfVisit.ToString()}   Price - {v.Price.ToString()} euro(s)");
                Console.WriteLine($"Description: {v.Description}");
            }
            EmptyLine();
        }

        private static void ShowFindPatientsResults(List<IPatient> list)
        {
            if (list.Count != 0)
            {
                foreach (var p in list)
                {
                    Console.WriteLine($"Patient {p.FirstName} {p.LastName} - {p.PESEL}");
                }
            }
            else
            {
                Console.WriteLine("Patient(s) does not exist.");
            }
            EmptyLine();
        }

        private static void ShowFindVisitsResults(List<IVisit> list)
        {
            if (list.Count != 0)
            {
                foreach (var v in list)
                {
                    Console.WriteLine($"Patient {v.Patient.FirstName} {v.Patient.LastName} - {v.Patient.PESEL}");
                    Console.WriteLine($"Date of visit: {v.DateOfVisit.ToString()}   Price - {v.Price.ToString()} euro(s)");
                    Console.WriteLine($"Description: {v.Description}");
                }
            }
            else
            {
                Console.WriteLine("Visit(s) does not exist.");
            }
            EmptyLine();
        }
    }
}
