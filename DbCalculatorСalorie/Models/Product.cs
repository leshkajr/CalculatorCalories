﻿using DbCalculatorСalorie.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCalculatorСalorie.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Protein { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public double Weight { get; set; }
        public float Calories { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? DietForTheDayId { get; set; }
        public DietForTheDay DietForTheDay { get; set; }

        public void AddProduct(string name,int protein,int carbohydrates,int fats,int CategoryId,Product product)
        {
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                var category = db.Categories.FirstOrDefault(x => x.id == CategoryId);
                Product newProduct = new Product() { Name = name, Protein = protein, Carbohydrates = carbohydrates, Fats = fats };
                newProduct.Weight = 100;
                newProduct.Calories = (int)(protein * 4.2 + fats * 9.29 + carbohydrates * 4.2);
                db.Products.Add(newProduct);
                category.Products.Add(newProduct);
                db.SaveChanges();
            }
        }
    }
}
