using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUsersRepository
    {
        void Initialize();
        User GetUserById(int id);
        IList<User> GetUsers();
        int AddUser(User user);
        bool EditUser(User user);
        bool DeleteUser(int id);
    }
}
