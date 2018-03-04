using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewsAbstraction
{
    public interface IEditView : IBaseView
    {
        Action AddUser { get; set; }
        Action EditUser { get; set; }

        int UserId { get; set; }
        string UserName { get; set; }
        int UserAge { get; set; }
    }
}
