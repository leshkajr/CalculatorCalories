using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCalculatorСalorie.Models;

namespace Search
{
    internal interface ISearchProduct
    {
        List<Product> Search(string name);
    }
}
