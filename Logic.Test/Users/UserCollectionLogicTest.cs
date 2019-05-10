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
            user = new User(1, "Nicky", "admin", "nicky@gmail.com");
            userCollectionLogic = new UserCollectionLogic(new UserRepository(new UserContextMemory()));
        }

        [TestMethod]
        public void AddUserTest()
        {
            Assert.AreEqual(true, userCollectionLogic.AddUser(user));
        }

        [TestMethod]
        public void LoginTest()
        {
            Assert.AreEqual(user, userCollectionLogic.Login(user.Username, user.Password));
        }

        [TestMethod]
        public void LoginWrongUsernameTest()
        {

        }

        [TestMethod]
        public void LoginWrongPasswordTest()
        {

        }
    }
}
