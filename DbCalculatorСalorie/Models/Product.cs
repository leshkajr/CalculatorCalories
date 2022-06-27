using DbCalculatorСalorie.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCalculatorСalorie.Models
{
    public class Product:IProduct
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Protein { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public double Weight { get; set; }
        public int Calories { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<DietForTheDay> DietForTheDays { get; set; }
        public Product()
        {
            DietForTheDays = new List<DietForTheDay>();
        }

        public void AddProduct(string name,int protein,int carbohydrates,int fats,int CategoryId,Product product)
        {
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                var category = db.Categories.FirstOrDefault(x => x.id == CategoryId);
                Product newProduct = new Product() { Name = name, Protein = protein, Carbohydrates = carbohydrates, Fats = fats };
                newProduct.Calories = (int)(protein * 4.2 + fats * 9.29 + carbohydrates * 4.2);
                db.Products.Add(newProduct);
                category.Products.Add(newProduct);
                db.SaveChanges();
            }
        }

        public void EditProduct()
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct()
        {
            throw new NotImplementedException();
        }
    }
}
