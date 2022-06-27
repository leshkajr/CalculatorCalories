using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Search
{
    public class SerchDiertForTheDay
    {
        public List<Product> Search(User user)
        {
            DateTime date = DateTime.Now;
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                var allProducts = db.Products.ToList();
                var SearchDietForTheDays = db.DietForTheDays.Where(x=>x.user.id == user.id).ToList();
                var dietForTheDays = SearchDietForTheDays.FirstOrDefault(x=>x.Date.Date == date.Date);
                if(dietForTheDays != null)
                {
                  
                    return dietForTheDays.Products.ToList();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
