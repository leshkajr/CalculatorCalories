using DbCalculatorСalorie.Date;
using DbCalculatorСalorie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text.Encryptor;

namespace Authorization.Users
{
    public class AuthorizationUser
    {
        public static User PasswordCheckAsync(string login,string password)
        {
            using (CalculatorСalorieDbContext db = new CalculatorСalorieDbContext())
            {
                User findUser = db.Users.FirstOrDefault(x => x.Login == login);
                if (findUser != null)
                {
                    if (findUser.Password == Encrypt.EncryptStr(password) )
                    {
                        return findUser;
                    }
                }
            }
          return null;
        }
    }
}
