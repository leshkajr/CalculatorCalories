using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCalculatorСalorie.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
    }
}
