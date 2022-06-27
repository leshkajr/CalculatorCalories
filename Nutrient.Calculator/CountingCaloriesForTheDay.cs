using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrient.Calculator
{
    public class CountingCaloriesForTheDay 
    {
        public Product NutrientCount(List<Product> products)
        {
            CountingCaloriesProduct countingCaloriesProduct = new CountingCaloriesProduct();    
            Product nutrientProducts=new Product();
            foreach (var product in products)
            {
                nutrientProducts.Protein+= product.Protein;
                nutrientProducts.Calories+= product.Calories;
                nutrientProducts.Fats += product.Fats;
                nutrientProducts.Carbohydrates+= product.Carbohydrates;
                nutrientProducts.Weight += product.Weight;
            }
            return nutrientProducts;
        }
    }
}
