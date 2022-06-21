using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCalculatorСalorie.Date
{
    public class CalculatorСalorieDbContext : DbContext
    {
        public CalculatorСalorieDbContext() : base("CalculatorСalorieDb")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
