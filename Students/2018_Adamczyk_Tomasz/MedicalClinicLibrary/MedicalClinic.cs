using MedicalClinic.Enums;
using MedicalClinic.Interfaces;
using MedicalClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MedicalClinic
{
    public class MedicalClinic
    {
        public List<IPatient> Patients { get; private set; }
        public List<IVisit> Visits { get; private set; }

        public MedicalClinic()
        {
            Patients = new List<IPatient>();
            Visits = new List<IVisit>();
        }

        public bool AddPatient(String firstName, String lastName, String pesel, Int32 age, Genders sex)
        {
            var patient = new Patient(firstName, lastName, pesel, age, sex);
            if (!Patients.Contains(patient))
            {
                Patients.Add(patient);
                return true;
            }
            else
                return false;
        }

        public List<IPatient> FindPatients(params String[] list)
        {
            var items = new List<IPatient>();
            foreach (String input in list)
            {
                items.AddRange(Patients.FindAll(
                            x => x.FirstName.ToLower().Contains(input.ToLower())
                            || x.LastName.ToLower().Contains(input.ToLower())
                            || x.PESEL.Contains(input)));
            }
            var result = items.Distinct().ToList();
            return result;
        }

        public IPatient FindPatient(params String[] list)
        {
            Patient item = null;
            foreach (String input in list)
            {
                var itemTmp = (Patient)Patients.Find(
                            x => x.FirstName.ToLower().Contains(input.ToLower())
                            || x.LastName.ToLower().Contains(input.ToLower())
                            || x.PESEL.Contains(input));
                if (item == null)
                {
                    item = itemTmp;
                }
                else
                    return null;
            }
            return item;
        }

        public int GetPatientsCounter()
        {
            return Patients.Count;
        }

        public bool AddVisit(Patient patient, DateTime dateOfVisit, String description, Decimal price)
        {
            var visit = new Visit(patient, dateOfVisit, description, price);
            if (!Visits.Contains(visit))
            {
                Visits.Add(visit);
                patient.Visits.Add(visit);
                return true;
            }
            else
                return false;
        }

        public List<IVisit> FindVisits(params String[] list)
        {
            var items = new List<IVisit>();
            foreach (String input in list)
            {
                items.AddRange(Visits.FindAll(
                            x => x.Patient.FirstName.ToLower().Contains(input.ToLower())
                            || x.Patient.LastName.ToLower().Contains(input.ToLower())
                            || x.Patient.PESEL.Contains(input)
                            || x.DateOfVisit.Equals(DateTime.Parse(input))
                            || x.DateOfVisit.Date == DateTime.Parse(input)));
            }
            var result = items.Distinct().ToList();
            return result;
        }

        public IVisit FindVisit(params String[] list)
        {
            Visit item = null;
            foreach (String input in list)
            {
                var itemTmp = (Visit)Visits.Find(
                                x => x.Patient.FirstName.ToLower().Contains(input.ToLower())
                                || x.Patient.LastName.ToLower().Contains(input.ToLower())
                                || x.Patient.PESEL.Contains(input)
                                || x.DateOfVisit.Equals(DateTime.Parse(input))
                                || x.DateOfVisit.Date == DateTime.Parse(input));
                if (item == null)
                {
                    item = itemTmp;
                }
                else
                    return null;
            }
            return item;
        }

        public int GetVisitsCounter()
        {
            return Visits.Count;
        }
    }
}
