using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrient.Calculator
{
    public interface ICalculator
    {
      Product NutrientCount(Product product,User user, DateTime date);
    }
}
