using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text.Encryptor;

namespace Registration.Users
{
    public class RegistrationUser
    {
        public bool CreateUser(string name, string login, string password, int gender, int age, decimal weight, decimal height)
        {
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                List<User> users = db.Users.ToList();
                var serchUser = db.Users.FirstOrDefault(x => x.Name == name);
                if (serchUser == null)
                {
                    User user = new User();
                    user.Name = name;
                    user.Login = login;
                    user.Password = Encrypt.EncryptStr(password);
                    user.Gender = gender;
                    user.Age = age;
                    user.Weight = weight;
                    user.Height = height;
                    db.Users.Add(user);
                    db.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
