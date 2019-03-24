using System;
using System.Collections.Generic;

namespace Kitchen
{
    interface IRecipe
    {
        Dictionary<Ingredient, Unit> elements { get; }
    }

    public class Recipe : IRecipe
    {
        private Dictionary<Ingredient, Unit> _elements;
        private double _multiplier;

        public Recipe(string name)
        {
            this.name = name;
            this._elements = new Dictionary<Ingredient, Unit>();
            this._multiplier = 1;
        }

        public string name
        {
            set;
            get;
        }

        public double multiplier
        {
            set
            {
                foreach (var entry in _elements)
                {
                    entry.Key.Multiply(value / _multiplier);
                }
                _multiplier = value;
            }
            get => _multiplier;
        }

        public Dictionary<Ingredient, Unit> elements
        {
            get => _elements;

        }

        public bool Add(Ingredient ingredient, Unit unit)
        {
            foreach (var entry in _elements)
            {
                if (entry.Key.GetName() == ingredient.GetName())
                    return false;
            }
            _elements.Add(ingredient, unit);
            return true;

        }

        public void Remove(Ingredient ingredient)
        {
            if (_elements.ContainsKey(ingredient))
                _elements.Remove(ingredient);
            else
                throw new ArgumentException();
        }

    }

    public class StubRecipe : IRecipe
    {
        public Dictionary<Ingredient, Unit> elements
        {
            get
            {
                Dictionary<Ingredient, Unit> dict = new Dictionary<Ingredient, Unit>();
                Unit unit = new Unit("gram", 'g', 1);
                dict.Add(new Ingredient("mąka", 240), unit);
                dict.Add(new Ingredient("sól", 288), unit);
                return dict;
            }
        }
    }
}
