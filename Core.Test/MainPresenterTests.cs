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

        [TestInitialize]
        public void Initialize()
        {
            usersRepository = new UsersRepository();
        }

        [TestMethod]
        public void DeleteUser()
        {
            var view = Substitute.For<IMainView>();
            var presenter = new MainPresenter(view, usersRepository);

            usersRepository.Initialize();
            var firstUser = usersRepository.GetUsers().First();
            view.DeleteAction(firstUser);
            Assert.IsFalse(usersRepository.GetUsers().Contains(firstUser));
        }
    }
}
