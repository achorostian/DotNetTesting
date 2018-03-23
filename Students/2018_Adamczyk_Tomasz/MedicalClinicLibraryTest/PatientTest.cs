using MedicalClinic.Enums;
using MedicalClinic.Interfaces;
using MedicalClinic.Models;
using MedicalClinic.Interfaces.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MedicalClinicLibraryTest
{
    [TestClass]
    public class PatientTest
    {
        Patient patient;

        [TestInitialize]
        public void SetUp()
        {
            patient = new Patient("Tomasz", "Adamczyk", "94010112345", 24, Genders.Male);
            patient.Visits = new List<IVisit>
            {
                new Visit(patient, DateTime.Parse("2018-01-02 12:15"), "Flu", 0M),
                new Visit(patient, DateTime.Parse("2018-01-22 09:00"), "Stomache", 0M)
            };
        }

        [TestMethod]
        [TestCategory("FullName")]
        public void ShouldPassWhenPatientFullNameIsCorrect()
        {
            var expected = "Tomasz Adamczyk";
            var actual = patient.FullName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("FirstName")]
        public void ShouldPassWhenPatientFirstNameIsCorrect()
        {
            var value = "Tomasz";
            var substring = patient.FirstName;
            StringAssert.Contains(value, substring);
        }

        [TestMethod]
        [TestCategory("LastName")]
        public void ShouldPassWhenFirstLetterOfPatientLastNameIsCorrect()
        {
            var value = "A";
            var substring = patient.LastName.Substring(0, 1);
            StringAssert.StartsWith(value, substring);
        }

        [TestMethod]
        [TestCategory("PESEL")]
        public void ShouldPassWhenPESELPatternIsCorrect()
        {
            var value = patient.PESEL;
            var pattern = new Regex("^[0-9]{11}$");
            StringAssert.Matches(value, pattern);
        }

        [TestMethod]
        [TestCategory("Age")]
        public void ShouldNotPassWhenPatientAgeIsLessOrGreater()
        {
            var notExpected = patient.Age - 1;
            var actual = patient.Age;
            Assert.AreNotEqual(notExpected, actual);
        }

        [TestMethod]
        [TestCategory("Gender")]
        public void ShouldPassWhenPatientSexIsTypeOfGender()
        {
            var value = patient.Sex;
            var expectedType = typeof(Genders);
            Assert.IsInstanceOfType(value, expectedType);
        }

        [TestMethod]
        [TestCategory("Visits")]
        public void ShouldPassWhenPatientVisitsAreTypeOfVisit()
        {
            var collection = patient.Visits;
            var expectedType = typeof(Visit);
            CollectionAssert.AllItemsAreInstancesOfType(collection, expectedType);
        }

        [TestMethod]
        [TestCategory("Visits")]
        public void ShouldPassWhenAllPatientVisitsAreUnique()
        {
            var collection = patient.Visits;
            CollectionAssert.AllItemsAreUnique(collection);
        }

        [TestMethod]
        [TestCategory("Visits")]
        public void ShouldIncreasePatientVisitsCounterWhenAddStubIVisit()
        {
            var collection = patient.Visits;
            var expected = collection.Count;
            collection.Add(new StubIVisit());
            var actual = collection.Count;
            Assert.AreEqual(expected + 1, actual);
        }
    }
}