using Kitchen;
using NUnit.Framework;
using System;
namespace KitchenTest
{
    [TestFixture()]
    public class RecipeTest
    {
        private Recipe recipe;
        private Ingredient water;
        private Unit unit;

        [SetUp]
        public void Init()
        {
            recipe = new Recipe("przepis na naleśniki");
            unit = new Unit("gram", 'g', 1);
            recipe.Add(new Ingredient("mąka", 240), unit);
            recipe.Add(new Ingredient("sól", 288), unit);
            recipe.Add(new Ingredient("mleko", 250), unit);
            recipe.Add(new Ingredient("jajka", 278), unit);
            water = new Ingredient("woda", 278);
            recipe.Add(water, unit);
            recipe.Add(new Ingredient("masło", 240), unit);
        }


        [Test()]
        public void AllRecipeElementsShouldBeNotNull()
        {
            CollectionAssert.AllItemsAreNotNull(recipe.elements);
        }

        [Test()]
        public void AllRecipeElementsShouldBeUnique()
        {
            CollectionAssert.AllItemsAreUnique(recipe.elements);
        }

        [Test()]
        public void RecipeShouldContainsWaterWithCorrectUnit()
        {
            Unit expected = unit;
            Unit actual = recipe.elements[water];

            Assert.AreEqual(expected,actual);
        }

        [Test()]
        public void AllRecipeElementsShouldBeUnique_Stub()
        {
            StubRecipe sr = new StubRecipe();
            CollectionAssert.AllItemsAreUnique(sr.elements);
        }
    }
}
