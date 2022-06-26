using DbCalculatorСalorie.Models;
using System.Collections.Generic;

namespace Products.Search
{
    public interface ISearchProduct
    {
        List<Product> Search(string name);
    }
}
