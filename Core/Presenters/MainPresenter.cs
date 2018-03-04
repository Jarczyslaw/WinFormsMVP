using Core.ViewsAbstraction;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Presenters
{
    public class MainPresenter
    {
        private IMainView view;
        private IUsersRepository usersRepository;

        public MainPresenter(IMainView view, IUsersRepository usersRepository)
        {
            this.view = view;
            this.usersRepository = usersRepository;

            view.AddUser += (v) => ShowEdit(v, null);
            view.EditUser += (v, u) => ShowEdit(v, u);
            view.DeleteUser += DeleteUser;
        }

        private void ShowEdit(IEditView editView, User user)
        {
            if (user == null)
            {
                user = new User()
                {
                    Id = 0,
                    Name = string.Empty,
                    Age = 30
                };
            }
                
            var editPresenter = new EditPresenter(editView, usersRepository);
            editPresenter.MainPresenter = this;
            editPresenter.Edit(user);
        }

        private void DeleteUser(User user)
        {
            usersRepository.DeleteUser(user.Id);
            Debug.WriteLine(string.Format("User with id: {0} deleted", user.Id));
            UpdateView();
        }

        public void ShowView()
        {
            UpdateView();
            view.OpenView();
        }

        public void UpdateView()
        {
            var users = usersRepository.GetUsers();
            view.Users = users;
        }
    }
}
