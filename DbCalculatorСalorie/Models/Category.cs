using DbCalculatorСalorie.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCalculatorСalorie.Models
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
        public override string ToString()
        {
            return $"{Name}";
        }


        public void AddProduct(string name, int protein, int carbohydrates, int fats, int CategoryId, Product product)
        {
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                Category category = new Category();
                category.Name = name;
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

    }
}
