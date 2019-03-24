using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen
{
    public class Ingredient
    {
        private string name;

        private double weightOf250M;

        private double actualM;
        private double actualG;

        public Ingredient(string name, double weightOf250M)
        {
            this.name = name;
            this.weightOf250M = weightOf250M;
            actualM = 0;
            actualG = 0;
        }

        public string GetName() => name;
        public double GetWeightOf250M() => weightOf250M;
        public double GetActualM() => actualM;
        public double GetActualG() => actualG;

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetWeightOf250M(double weightOf250M)
        {
            this.weightOf250M = weightOf250M;
        }

        public void Multiply(double multiplier)
        {
            actualG = actualG * multiplier;
            actualM = actualM * multiplier;
        }

        public void SetActualFromUnit(Unit unit , double value)
        {
            if (unit.GetBaseUnit() == 'g')
            {
                actualG = unit.GetNumberOfBaseUnits() * value;
                actualM = (actualG * 250) / weightOf250M;
            }
            else
            {
                if (unit.GetBaseUnit() == 'm')
                {
                    actualM = unit.GetNumberOfBaseUnits() * value;
                    actualG = (actualM * weightOf250M) / 250;
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        public double GetActualToUnit(Unit unit)
        {
            if (unit.GetBaseUnit() == 'g')
            {
                return (actualG / unit.GetNumberOfBaseUnits());
            }
            else
            {
                if (unit.GetBaseUnit() == 'm')
                {
                    return (actualM / unit.GetNumberOfBaseUnits());
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }


    }
}
