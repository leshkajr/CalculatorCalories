using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using System.Collections.Generic;
using System.Linq;

namespace Products.Search
{
    public class SearchProductFilter
    {
        public List<Product> Search(string name)
        {
            if (name != null)
            {
                name = name.ToLower();
            }
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                var products = new List<Product>();
                products = db.Products.Where(c => c.Name.ToLower().Contains(name) && c.CategoryId!=null).ToList();
                return products;
            }
        }
    }
}
