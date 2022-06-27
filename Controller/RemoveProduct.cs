using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RemoveProduct
    {
        public void RemoveProductI(int id) //отправляем id выбранного продукта и удаляем его из базы данных.
        {
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                Product rmv = db.Products.Where(r => r.id == id).FirstOrDefault();
                if (rmv != null)
                {
                    db.Products.Remove(rmv);
                    db.SaveChanges();
                }
            }
        }
    }
}