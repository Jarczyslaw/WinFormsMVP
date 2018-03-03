using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Data.Models;

namespace Data.Test
{
    [TestClass]
    public class UsersRepositoryTest
    {
        [TestMethod]
        public void Initialize()
        {
            var repository = new UsersRepository();
            repository.Initialize();
            Assert.AreEqual(3, repository.GetUsers().Count);
        }

        [TestMethod]
        public void GetUserById()
        {
            var repository = new UsersRepository();
            repository.Initialize();
            var existingUser = repository.GetUserById(1);
            var notExistingUser = repository.GetUserById(10);
            Assert.IsNotNull(existingUser);
            Assert.IsNull(notExistingUser);
        }

        [TestMethod]
        public void AddUser()
        {
            var repository = new UsersRepository();
            repository.Initialize();
            var initialCount = repository.GetUsers().Count;
            repository.AddUser(new User());
            Assert.AreEqual(initialCount + 1, repository.GetUsers().Count);
        }

        [TestMethod]
        public void EditUser()
        {
            var id = 1;
            var newName = "TestName";

            var repository = new UsersRepository();
            repository.Initialize();
            var user = repository.GetUserById(id);
            user.Name = newName;
            repository.EditUser(user);
            Assert.AreEqual(newName, repository.GetUserById(id).Name);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var id = 1;

            var repository = new UsersRepository();
            repository.Initialize();
            var initialCount = repository.GetUsers().Count;
            repository.DeleteUser(id);
            Assert.IsNull(repository.GetUserById(id));
        }
    }
}
