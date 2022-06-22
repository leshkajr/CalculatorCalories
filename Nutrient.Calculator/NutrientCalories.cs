using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrient.Calculator
{
    public class NutrientCalories
    {
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public NutrientCalories()
        {
            Protein = 4.2;
            Fats = 9.29;
            Carbohydrates = 4.2;
        }
    }
}
