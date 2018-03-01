using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UsersRepository : IUsersRepository
    {
        private List<User> users = new List<User>();

        public UsersRepository()
        {
            Initialize();
        }

        public User GetUserById(int id)
        {
            return users.Where(u => u.Id == id).SingleOrDefault();
        }

        public IList<User> GetUsers()
        {
            return users;
        }

        public int AddUser(User user)
        {
            int newId = users.Max(u => u.Id) + 1;
            user.Id = newId;
            users.Add(user);
            return newId;
        }

        public bool EditUser(User user)
        {
            var editedUser = users.Where(u => u.Id == user.Id).SingleOrDefault();
            if (editedUser == null)
                return false;
            else
            {
                editedUser.Name = user.Name;
                editedUser.Age = user.Age;
                return true;
            }
        }

        public bool DeleteUser(int id)
        {
            var u = GetUserById(id);
            if (u != null)
            {
                users.Remove(u);
                return true;
            }
            else
                return false;
        }

        private void Initialize()
        {
            users.Clear();
            users.Add(new User()
            {
                Id = 1,
                Name = "John",
                Age = 20
            });
            users.Add(new User()
            {
                Id = 2,
                Name = "Peter",
                Age = 30
            });
            users.Add(new User()
            {
                Id = 3,
                Name = "George",
                Age = 40
            });
        }
    }
}
