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
    }
}
