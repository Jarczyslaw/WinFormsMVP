using System;
using System.Linq;
using Core.Presenters;
using Core.ViewsAbstraction;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Core.Test
{
    [TestClass]
    public class MainPresenterTests
    {
        private IUsersRepository usersRepository;
        private IMainView view;
        private MainPresenter presenter;

        [TestInitialize]
        public void Initialize()
        {
            usersRepository = new UsersRepository();
            view = Substitute.For<IMainView>();
            presenter = new MainPresenter(view, usersRepository);
        }

        [TestMethod]
        public void ShowUsers()
        {
            usersRepository.Initialize();
            presenter.UpdateView();
            CollectionAssert.AreEqual(usersRepository.GetUsers().ToList(), view.Users.ToList());
        }

        [TestMethod]
        public void DeleteUser()
        {
            usersRepository.Initialize();
            var firstUser = usersRepository.GetUsers().First();
            view.DeleteUser(firstUser);
            Assert.IsFalse(usersRepository.GetUsers().Contains(firstUser));
        }
    }
}
