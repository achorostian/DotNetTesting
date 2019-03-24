using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    public class Unit
    {
        private string name;
        private char baseUnit; // 'g' or 'm'
        private double numberOfBaseUnits;

        public Unit(string name, char baseUnit , double numberOfBaseUnits)
        {
            if (baseUnit != 'g' && baseUnit != 'm')
                throw new ArgumentOutOfRangeException();

            this.name = name;
            this.baseUnit = baseUnit;
            this.numberOfBaseUnits = numberOfBaseUnits;
        }

        public char GetBaseUnit() => baseUnit;
        public string GetName() => name;
        public double GetNumberOfBaseUnits() => numberOfBaseUnits;

        public void SetBaseUnit(char baseUnit)
        {
            if (baseUnit != 'g' && baseUnit != 'm')
                throw new ArgumentOutOfRangeException();
            this.baseUnit = baseUnit;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetNumberOfBaseUnits(double numberOfBaseUnits)
        {
            this.numberOfBaseUnits = numberOfBaseUnits;
        }

    }
}
