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
        Action<IEditView> AddAction { get; set; }
        Action<IEditView, User> EditAction {get;set;}
        Action<User> DeleteAction { get; set; }

        void UpdateUsers(IList<User> users);
    }
}
