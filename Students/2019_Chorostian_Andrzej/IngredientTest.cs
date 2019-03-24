using Kitchen;
using NUnit.Framework;
using System;
namespace KitchenTest
{
    [TestFixture()]
    public class IngredientTest
    {

        // samples
        //
        // Ingredient sugar = new Ingredient("cukier",240);
        // Ingredient salt = new Ingredient("sól", 288);
        // Ingredient flour = new Ingredient("mąka", 140);
        // Ingredient butter = new Ingredient("masło", 240);
        // Ingredient milk = new Ingredient("mleko", 250);
        // Ingredient water = new Ingredient("woda", 250);

        [Test()]
        public void NewCorrectIngredient_NameTest()
        {
            Ingredient sugar = new Ingredient("cukier", 240);
            string actual = sugar.GetName();
            string expected = "cukier";
            StringAssert.AreEqualIgnoringCase(expected,actual);
        }

        [Test()]
        public void NewCorrectIngredient_WeightOf250MTest()
        {
            Ingredient sugar = new Ingredient("cukier", 240);
            double actual = sugar.GetWeightOf250M();
            double expected = 240;
            Assert.AreEqual(expected, actual);
        }

        [TestCase("cukier",240,0.5,120)]
        [TestCase("sól",288,4,1152)]
        [TestCase("mąka",140,0.4,56)]
        [TestCase("masło",240,2,480)]
        [TestCase("mleko",250,0.004,1)]
        public void CheckConversionData(string name,double weightOf250M, double givenCups , double expectedG)
        {
            Ingredient ingredient = new Ingredient(name, weightOf250M);
            Unit cup = new Unit("szklanka", 'm', 250);
            ingredient.SetActualFromUnit(cup, givenCups);
            double actual = ingredient.GetActualG();

            Assert.AreEqual(expectedG, actual);
        }

    }
}
