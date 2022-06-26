using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search
{
    public class SearchProduct : ISearchProduct
    {
        public List<Product> Search(string name)
        {
            name = name.ToLower();

            CalculatorСalorieDbContext db = new CalculatorСalorieDbContext();
            List<Product> products = new List<Product>();
            if (name.Trim() != "")
            {
                foreach (Product product in db.Products)
                {
                    if (product.Name.ToLower().Contains(name))
                    {
                        products.Add(product);
                    }
                }
                return products;
            }
            else
            {
                return db.Products.ToList();
            }


            //List<Product> db = new List<Product>(){
            //    new Product("Помидор",300),
            //    new Product("Картошка",20),
            //};

            //List<Product> products = new List<Product>();
            //if (name.Trim() != "")
            //{
            //    foreach (Product product in db)
            //    {
            //        if (product.Name.ToLower().Contains(name))
            //        {
            //            products.Add(product);
            //        }
            //    }
            //    return products;
            //}
            //else
            //{
            //    return db;
            //}
        }  
    }
}
