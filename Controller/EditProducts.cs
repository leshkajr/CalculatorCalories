using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using Nutrient.Calculator;
using System.Linq;

namespace Controller
{
    public class EditProducts
    {
        public Product SearchProductForEdit(int id) //наверняка у вас тут есть какоето окно редактирования, отправив id сюда получаем продукт для вывода его данных в это окно. p.s. если нет значит переделаю.
        {
            Product ed;
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                ed = db.Products.Where(r => r.id == 8).FirstOrDefault();
            }
            return ed;
        }
       public void Editing(Product edited, int protein, int carbohydrates, int fats) //отправляем изменяемый объект и все строки из окна изменения и сохраняем изменения в базу данных.
        {
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                CountingCaloriesProduct countingCalories = new CountingCaloriesProduct();
                var ed = db.Products.Where(e => e.id == edited.id).FirstOrDefault();
                ed.Protein = protein;
                ed.Carbohydrates = carbohydrates;
                ed.Fats = fats;
                ed = countingCalories.NutrientCount(ed, null, new System.DateTime());
                db.SaveChanges();
            }
        }
    }
}