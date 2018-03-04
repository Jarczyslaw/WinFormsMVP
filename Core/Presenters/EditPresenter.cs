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
    public class EditPresenter
    {
        private IEditView view;
        private IUsersRepository userRepository;

        public MainPresenter MainPresenter { get; set; }

        public EditPresenter(IEditView view, IUsersRepository userRepository)
        {
            this.view = view;
            this.userRepository = userRepository;

            view.AddUser += AddUser;
            view.EditUser += EditUser;
        }

        private void AddUser()
        {
            var editedUser = GetUserFromView();
            int newId = userRepository.AddUser(editedUser);
            Debug.WriteLine(string.Format("User with id: {0} added", newId));
            MainPresenter?.UpdateView();
        }

        private void EditUser()
        {
            var newUser = GetUserFromView();
            userRepository.EditUser(newUser);
            Debug.WriteLine(string.Format("User with id: {0} edited", newUser.Id));
            MainPresenter?.UpdateView();
        }

        public void Edit(User user)
        {
            SetUserToView(user);
            view.OpenView();
        }

        private void SetUserToView(User user)
        {
            view.UserId = user.Id;
            view.UserName = user.Name;
            view.UserAge = user.Age;
        }

        private User GetUserFromView()
        {
            var user = new User()
            {
                Id = view.UserId,
                Name = view.UserName,
                Age = view.UserAge
            };
            return user;
        }
    }
}
