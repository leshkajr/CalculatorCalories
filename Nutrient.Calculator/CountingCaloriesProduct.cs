using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrient.Calculator
{
    public class CountingCaloriesProduct : NutrientCalories, ICalculator
    {
        public Product NutrientCount(Product product, User user, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
