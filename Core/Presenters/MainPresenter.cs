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

            view.AddAction += (v) => ShowEdit(v, null);
            view.EditAction += (v, u) => ShowEdit(v, u);
            view.DeleteAction += DeleteUser;
        }

        private void ShowEdit(IEditView editView, User user)
        {
            var editPresenter = new EditPresenter(editView, usersRepository);
            editPresenter.SetUser(user);
            var changesMade = editPresenter.ShowView();
            if (changesMade)
                UpdateView();
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

        private void UpdateView()
        {
            var users = usersRepository.GetUsers();
            view.UpdateUsers(usersRepository.GetUsers());
        }
    }
}
