using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewsAbstraction
{
    public interface IEditView
    {
        Action<User> SaveUser { get; set; }

        void SetAsNew(bool newUser);
        void LoadUser(User user);
        void Open();
    }
}
