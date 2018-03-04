using System;
using System.Linq;
using Core.Presenters;
using Core.ViewsAbstraction;
using Data;
using Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Core.Test
{
    [TestClass]
    public class EditPresenterTests
    {
        private IUsersRepository usersRepository;

        [TestInitialize]
        public void Initialize()
        {
            usersRepository = new UsersRepository();
        }

        [TestMethod]
        public void ShowUser()
        {
            var user = new User()
            {
                Id = 10,
                Name = "TestUser",
                Age = 321
            };

            var view = Substitute.For<IEditView>();
            var presenter = new EditPresenter(view, usersRepository);
            presenter.Edit(user);

            Assert.AreEqual(view.UserId, user.Id);
            Assert.AreEqual(view.UserName, user.Name);
            Assert.AreEqual(view.UserAge, user.Age);
        }

        [TestMethod]
        public void AddUser()
        {
            usersRepository.Initialize();

            var view = Substitute.For<IEditView>();
            var userName = "TestUser";
            view.UserId.Returns(0);
            view.UserName.Returns(userName);
            view.UserAge.Returns(123);

            var presenter = new EditPresenter(view, usersRepository);
            view.AddUser();
            Assert.IsTrue(usersRepository.GetUsers().Count(u => u.Name == userName) == 1);
        }

        [TestMethod]
        public void EditUser()
        {
            usersRepository.Initialize();

            var view = Substitute.For<IEditView>();
            var id = 1;
            view.UserId.Returns(id);
            view.UserName.Returns("TestUser");
            view.UserAge.Returns(123);

            var presenter = new EditPresenter(view, usersRepository);
            view.EditUser();

            var user = usersRepository.GetUserById(id);
            Assert.IsTrue(user.Name == view.UserName && user.Age == view.UserAge);
        }
    }
}
