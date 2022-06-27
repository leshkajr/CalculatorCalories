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
        /// <summary>
        /// Последние 2 аргумента игнорируются.
        /// Значения полей аргумента product(protein, fats, carbohydrates) принимаются как значения для 100 граммов. Значение поля weight принимается как масса для которой нужно пересчитать значения.
        /// Будут изменены: protein, fats, carbohydrates, calories.
        /// </summary>
        /// <param name="product">Продукт для которого нужно пересчитать значения</param>
        /// <param name="user">Игнорируется</param>
        /// <param name="date">Игнорируется</param>
        /// <returns>Возвращает изменённый product</returns>
        public Product NutrientCount(Product product, User user, DateTime date)
        {
            product.Protein = (product.Weight * product.Protein) / 100;
            product.Fats = (product.Weight * product.Fats) / 100;
            product.Carbohydrates = (product.Weight * product.Carbohydrates) / 100;

            product.Calories = (int)(product.Fats * this.Fats + product.Carbohydrates * this.Carbohydrates + product.Protein * this.Protein);
            return product;
        }
    }
}
