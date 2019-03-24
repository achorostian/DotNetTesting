using Kitchen;
using NUnit.Framework;
using System;
namespace KitchenTest
{
    [TestFixture()]
    public class UnitTest
    {

        // samples
        //
        // Unit ml = new Unit("ml", 'm', 1);
        // Unit g = new Unit("g", 'g', 1);
        // Unit cup = new Unit("szklanka", 'm', 250);
        // Unit tablespoon = new Unit("łyżka stołowa", 'm', 15);
        // Unit teaspoon = new Unit("łyżeczka", 'm', 5);
        // Unit l = new Unit("l", 'm', 1000);

        [Test()]
        public void NewCorrectUnit_NumberOfBaseUnitsTest()
        {
            Unit cup = new Unit("szklanka", 'm', 250);
            double expected = 250;
            double actual = cup.GetNumberOfBaseUnits();
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void NewCorrectUnit_NameTest()
        {
            Unit tablespoon = new Unit("łyżka stołowa", 'm', 15);
            string value = tablespoon.GetName();
            string substring = "łyż";
            StringAssert.Contains(substring, value);
        }

        [Test()]
        public void NewCorrectUnit_BaseUnitTest()
        {
            Unit teaspoon = new Unit("łyżeczka", 'm', 5);
            char expected = 'm';
            char actual = teaspoon.GetBaseUnit();

            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void NewWrongUnit_BaseUnitTest()
        {
            Unit cup;
            Assert.That(() => cup = new Unit("szklanka", 'f', 250), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test()]
        public void ChangeCorrectUnit_NumberOfBaseUnitsTest()
        {
            Unit teaspoon = new Unit("łyżeczka", 'm', 50);
            teaspoon.SetNumberOfBaseUnits(5.8);
            double expected = 5.8;
            double actual = teaspoon.GetNumberOfBaseUnits();
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ChangeCorrectUnit_NameTest()
        {
            Unit teaspoon = new Unit("łyżeczka", 'm', 5);
            teaspoon.SetName("łyżeczka do herbaty");
            string expected = "łyżeczka do herbaty";
            string actual = teaspoon.GetName();
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ChangeCorrectUnit_BaseUnitTest()
        {
            Unit spoon = new Unit("łyżka", 'g', 500);
            spoon.SetBaseUnit('m');
            spoon.SetNumberOfBaseUnits(5.8);
            char expected = 'm';
            char actual = spoon.GetBaseUnit();
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ChangeWrongUnit_BaseUnitTest()
        {
            Unit teaspoon = new Unit("łyżeczka", 'm', 5);
            Assert.That(() => teaspoon.SetBaseUnit('d'), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
