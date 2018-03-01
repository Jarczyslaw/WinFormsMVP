using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewsAbstraction
{
    public interface IMainView
    {
        Action<IEditView> AddAction { get; set; }
        Action<IEditView, User> EditAction {get;set;}
        Action<User> DeleteAction { get; set; }

        void Open();
        void UpdateUsers(IList<User> users);
    }
}
