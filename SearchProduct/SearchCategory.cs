using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Search
{
    public class SearchCategory
    {
        public List<Category> Search()
        {
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                var categories = db.Categories.OrderBy(c=>c.Name).ToList();
                return categories;
            }
        }
    }
}
