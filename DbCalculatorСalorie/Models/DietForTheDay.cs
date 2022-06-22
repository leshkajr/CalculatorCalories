using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCalculatorСalorie.Models
{
    public class DietForTheDay
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
        public DietForTheDay()
        {
            Products = new List<Product>();
        }
    }
}
