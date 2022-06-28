using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Search
{
    public class SearchProduct : ISearchProduct
    {
        public List<Product> Search(string name, int categoryId)
        {
            if (name != null)
            {
                name = name.ToLower();
            }

            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                var categori = db.Categories.FirstOrDefault(x => x.id == categoryId);
                var products = new List<Product>();


                if(categori!=null)
                {
                    if(name.Trim()!="")
                    {
                        if(categori.Name=="Все")
                        {
                            products = db.Products.Where(x => x.CategoryId != null).ToList();
                            products = products.Where(c => c.Name.ToLower().Contains(name)).ToList();
                        }
                        else if(categori.id > 0)
                        {
                            products = db.Products.Where(x => x.CategoryId == categori.id).ToList();
                            products = products.Where(c => c.Name.ToLower().Contains(name)).ToList();
                        }
                       
                    }
                    else if (categori.id > 0 && categori.Name != "Все")
                    {
                        products = db.Products.Where(x => x.CategoryId == categori.id).ToList();
                    }
                    else
                    {
                        products = db.Products.Where(x => x.CategoryId != null).ToList();
                    }
                    return products;
                }
                else
                {
                    if (name.Trim() != "")
                    {
                        products = db.Products.Where(x => x.CategoryId != null).ToList();
                        products = products.Where(c => c.Name.ToLower().Contains(name)).ToList();
                    }
                    else
                    {
                        products = db.Products.Where(x => x.CategoryId != null).ToList();
                        products = products.Where(c => c.Name.ToLower().Contains(name)).ToList();
                    }
                    return products;
                }
            }
        }
    }
}
