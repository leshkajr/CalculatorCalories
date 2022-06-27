using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using System.Linq;

namespace Controller
{
    public class EditUser
    {
        public void Edit(User user)
        {
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                User serchUser = db.Users.FirstOrDefault(x => x.id == user.id);
                serchUser.Weight=user.Weight;
                serchUser.Height = user.Height;
                serchUser.Age = user.Age;
                db.SaveChanges();
            }
        }
    }
}
