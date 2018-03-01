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

        private User user;

        private bool changesMade = false;
        private bool newUser = false;

        public EditPresenter(IEditView view, IUsersRepository userRepository)
        {
            this.view = view;
            this.userRepository = userRepository;
            view.SaveUser += SaveUser;
        }

        public void SetUser(User user)
        {
            if (user == null)
            {
                this.user = new User(string.Empty, 30);
                newUser = true;
            }
            else
                this.user = user;
            view.SetAsNew(newUser);
        }

        private void SaveUser(User user)
        {
            if (newUser)
            {
                int newId = userRepository.AddUser(user);
                Debug.WriteLine(string.Format("User with id: {0} added", newId));
            }  
            else
            {
                userRepository.EditUser(user);
                Debug.WriteLine(string.Format("User with id: {0} edited", user.Id));
            }  
            changesMade = true;
        }

        public bool ShowView()
        {
            view.LoadUser(user);
            view.Open();
            return changesMade;
        }
    }
}
