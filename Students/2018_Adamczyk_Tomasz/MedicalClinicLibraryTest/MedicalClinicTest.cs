using MedicalClinic.Enums;
using MedicalClinic.Interfaces;
using MedicalClinic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MedicalClinicLibraryTest
{
    [TestClass]
    public class MedicalClinicTest
    {
        public TestContext TestContext { get; set; }

        MedicalClinic.MedicalClinic clinic;

        [TestInitialize]
        public void SetUp()
        {
            clinic = new MedicalClinic.MedicalClinic();
            clinic.AddPatient("Tomasz", "Adamczyk", "94010112345", 24, Genders.Male);
            clinic.AddPatient("Adam", "Kownacki", "97010112345", 21, Genders.Male);
            clinic.AddVisit((Patient)clinic.Patients[0], DateTime.Parse("2018-03-20 09:00"), "Stomache", 10M);
            clinic.AddVisit((Patient)clinic.Patients[1], DateTime.Parse("2017-03-20 09:15"), "Flu", 0M);
        }

        [TestMethod]
        [DataSource
            ("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"ListOfPatients.csv",
            "ListOfPatients#csv",
            DataAccessMethod.Sequential),
            DeploymentItem("ListOfPatients.csv")]
        [TestCategory("AddPatient")]
        public void ShouldPassAddPatientFromCSVFile()
        {
            var expected = clinic.GetPatientsCounter();
            String firstName = TestContext.DataRow["FirstName"].ToString();
            String lastName = TestContext.DataRow["LastName"].ToString();
            String pesel = TestContext.DataRow["PESEL"].ToString();
            Int32 age = Int32.Parse(TestContext.DataRow["Age"].ToString());
            Genders sex = (Genders)Enum.Parse(typeof(Genders), TestContext.DataRow["Sex"].ToString());
            clinic.AddPatient(firstName, lastName, pesel, age, sex);
            expected = expected + 1;
            var actual = clinic.GetPatientsCounter();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("FindPatients")]
        public void ShouldPassFindPatientsWhenInputOneOrMorePhrases()
        {
            var actual = clinic.FindPatients("Adam", "9");
            var expected = new List<IPatient>()
            {
                new Patient("Tomasz", "Adamczyk", "94010112345", 24, Genders.Male),
                new Patient("Adam", "Kownacki", "97010112345", 21, Genders.Male)
            };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("AddVisit")]
        public void ShouldPassAddVisitAndIncreaseVisitsCounterForSomePatient()
        {
            var expected = clinic.GetVisitsCounter();
            var expectedVisitsCounter = 1;
            clinic.AddVisit((Patient)clinic.FindPatient("940101"), DateTime.Parse("2018-03-20 09:00"), "Stomache", 0M);
            expected = expected + 1;
            var actual = clinic.GetVisitsCounter();
            Assert.AreEqual(expected, actual);

            // Patients[0] should have one more visit now
            expectedVisitsCounter = expectedVisitsCounter + 1;
            var actualVisitsCounter = clinic.Patients[0].Visits.Count;
            Assert.AreEqual(expectedVisitsCounter, actualVisitsCounter);
        }

        [TestMethod]
        [TestCategory("FindVisits")]
        public void ShouldPassFindVisitsForDateOfVisitOrPatientDetails()
        {
            var actual = clinic.FindVisits("2018-03-20");
            var expected = new List<IVisit>()
            {
                new Visit((Patient)clinic.Patients[0], DateTime.Parse("2018-03-20 09:00"), "Stomache", 10M)
            };
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
