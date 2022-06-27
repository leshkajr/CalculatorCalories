using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using Nutrient.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class AddDietForTheDay
    {
        public void AddProduct(string name, int protein, int carbohydrates, int fats, int CategoryId, Product product,User user)
        {
            DateTime date = DateTime.Now;
            CountingCaloriesProduct countingCaloriesProduct = new CountingCaloriesProduct();
            
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                List<DietForTheDay> dietForTheDays = new List<DietForTheDay>();
                dietForTheDays = db.DietForTheDays.ToList();
                var serchDay = dietForTheDays.FirstOrDefault(x => x.Date.Date == date.Date);
                if (serchDay != null)
                {
                    Product newProduct = product;
                    newProduct = countingCaloriesProduct.NutrientCount(product, null, date);
                    newProduct.CategoryId = null;
                    serchDay.Products.Add(product);
                }
                else
                {
                    Product newProduct = product;
                    newProduct = countingCaloriesProduct.NutrientCount(product, null, date);
                    DietForTheDay newDay = new DietForTheDay() { Date = date, userId = user.id };
                    newDay.Date = date;
                    newProduct.CategoryId = null;
                    newDay.Products.Add(newProduct);
                    db.DietForTheDays.Add(newDay); 
                }
                db.SaveChanges();
            }
        }
    }
}
