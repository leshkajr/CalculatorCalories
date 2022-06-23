using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCalculatorСalorie
{
    public interface IProduct
    {
        void AddProduct(string name, int protein, int carbohydrates, int fats, int CategoryId);
        void EditProduct();
        void RemoveProduct();
    }
}
