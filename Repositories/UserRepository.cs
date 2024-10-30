using JWT.Models;
using System.Collections;

namespace JWT.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            IEnumerable<User> users = new List<User>
            {
                new User { ID = 1, UserName = "Luiz", Password = "Luiz", Role="Admin" },
                new User { ID = 2, UserName = "Palinkas", Password = "Palinkas10@", Role="User" }
            };

            return users.Where(u => u.UserName.ToLower() == username.ToLower() && u.Password == password).FirstOrDefault();

        }
    }
}