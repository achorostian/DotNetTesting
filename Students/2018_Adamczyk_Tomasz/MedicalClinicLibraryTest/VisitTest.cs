using MedicalClinic.Enums;
using MedicalClinic.Interfaces;
using MedicalClinic.Models;
using MedicalClinic.Interfaces.Fakes;
using MedicalClinic.Models.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace MedicalClinicLibraryTest
{
    [TestClass]
    public class VisitTest
    {
        Visit visit;

        [TestInitialize]
        public void SetUp()
        {
            IPatient patient = new StubIPatient();
            visit = new Visit(patient, DateTime.Parse("2017-12-29 09:00"), "Flu", 0M);
        }

        [TestMethod]
        [TestCategory("Patient")]
        public void ShouldBeEqualsPatientRealTypeWithPatientAddedInVisitType()
        {
            var patient = new Patient("Tomasz", "Adamczyk", "94010112345", 24, Genders.Male);
            visit.Patient = patient;
            StringAssert.Equals(patient, visit.Patient);
        }

        [TestMethod]
        [TestCategory("DateOfVisit")]
        public void ShouldPassGetYearFromDateOfVisitForAllInstancesWithUsingShim()
        {
            using (ShimsContext.Create())
            {
                // year = 2018
                ShimVisit.AllInstances.DateOfVisitGet = (Visit) => DateTime.Parse("2018-01-01 09:00");
                int expected = 2018;
                int actual = visit.DateOfVisit.Year;
                Assert.AreEqual(expected, actual);

                // year = 2017
                ShimVisit.AllInstances.DateOfVisitGet = (Visit) => DateTime.Parse("2017-01-01 09:00");
                expected = 2017;
                actual = visit.DateOfVisit.Year;
                Assert.AreEqual(expected, actual);

                // year = 2000, check year in new Visit instance
                var v = new Visit();
                ShimVisit.AllInstances.DateOfVisitGet = (Visit) => DateTime.Parse("2000-01-01 09:00");
                expected = 2000;
                actual = v.DateOfVisit.Year;
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod]
        [TestCategory("DateOfVisit")]
        public void ShouldDoNotThrowExceptionWhenDateOfVisitIsInFutureWithUsingShim()
        {
            using (ShimsContext.Create())
            {
                ShimVisit.DateOfVisitIsValidDateTime = (dateOfVisit) => true;
                var v = new Visit(new StubIPatient(), DateTime.Parse("2020-01-01 09:00"), "Flu", 0M);
            }
        }

        [TestMethod]
        [TestCategory("Description")]
        public void ShouldPassWhenDescriptionPatternIsCorrect()
        {
            using (ShimsContext.Create())
            {
                ShimVisit.AllInstances.DescriptionGet = (Visit) => "Enter the description of the visit here (diagnosis, recommendations etc.).";
                var value = visit.Description;
                var pattern = new Regex("^.{0,500}$");
                StringAssert.Matches(value, pattern);
            }
        }

        [TestMethod]
        [TestCategory("Price")]
        [ExpectedException(typeof(Exception))]
        public void ShouldThrowExceptionWhenPriceIsNegative()
        {
            var negativePrice = -1M;
            var v = new Visit(new StubIPatient(), new DateTime(), "", negativePrice);
        }
    }
}
