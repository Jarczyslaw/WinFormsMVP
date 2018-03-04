using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewsAbstraction
{
    public interface IMainView : IBaseView
    {
        Action<IEditView> AddUser { get; set; }
        Action<IEditView, User> EditUser {get;set;}
        Action<User> DeleteUser { get; set; }

        IList<User> Users { get; set; }
    }
}
