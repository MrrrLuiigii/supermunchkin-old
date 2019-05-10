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

        [TestInitialize]
        public void TestInitialize()
        {
            userCollectionLogic = new UserCollectionLogic();
        }

        [TestMethod]
        public void AddUserTest()
        {
            User user = new User("NewUser", "password", "new@email.com");
            userCollectionLogic.AddUser(user);
        }
    }
}
