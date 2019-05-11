using DAL.Contexts.Users;
using DAL.Repositories;
using Factories;
using Logic.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Models.Enums;

namespace Logic.Test.Users
{
    [TestClass]
    public class UserCollectionLogicTest
    {
        UserCollectionLogic userCollectionLogic;
        User user;

        [TestInitialize]
        public void TestInitialize()
        {
            user = new User("Nicky", "admin", "nicky@gmail.com");
            userCollectionLogic = new UserCollectionLogic(UserFactory.GetUserCollectionRepositoryTest());
        }

        [TestMethod]
        public void AddUserTest()
        {
            user.Username = "NewUser";
            user.Email = "newuser@gmail.com";
            Assert.AreEqual(true, userCollectionLogic.AddUser(user));
        }

        [TestMethod]
        public void AddUserUsernameTakenTest()
        {
            user.Email = "newemail@gmail.com";
            Assert.AreEqual(false, userCollectionLogic.AddUser(user));
        }

        [TestMethod]
        public void AddUserEmailTakenTest()
        {
            user.Username = "NewUser";
            Assert.AreEqual(false, userCollectionLogic.AddUser(user));
        }

        [TestMethod]
        public void LoginTest()
        {
            Assert.AreEqual(user, userCollectionLogic.Login(user.Username, user.Password));
        }

        [TestMethod]
        public void LoginWrongUsernameTest()
        {
            Assert.AreEqual(null, userCollectionLogic.Login("Nickyy", "admin"));
        }

        [TestMethod]
        public void LoginWrongPasswordTest()
        {
            Assert.AreEqual(null, userCollectionLogic.Login("Nicky", "wrong"));
        }
    }
}
