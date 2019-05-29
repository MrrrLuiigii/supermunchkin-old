using Factories;
using Logic.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace Logic.Test.Users
{
    [TestClass]
    public class UserCollectionLogicIntegrationTest
    {
        UserCollectionLogic userCollectionLogic;
        User user;

        [TestInitialize]
        public void TestInitialize()
        {
            userCollectionLogic = new UserCollectionLogic(UserFactory.GetUserCollectionRepositoryTest());
            user = new User(1, "Nicky", "admin", "nicky@gmail.com");
        }

        [TestMethod]
        public void AddUserTest()
        {
            user.Username = "NewUser";
            user.Email = "newuser@gmail.com";
            Assert.IsTrue(userCollectionLogic.AddUser(user));
        }

        [TestMethod]
        public void AddUserUsernameTakenTest()
        {
            user.Email = "newemail@gmail.com";
            Assert.IsFalse(userCollectionLogic.AddUser(user));
        }

        [TestMethod]
        public void AddUserEmailTakenTest()
        {
            user.Username = "NewUser";
            Assert.IsFalse(userCollectionLogic.AddUser(user));
        }

        [TestMethod]
        public void LoginTest()
        {
            Assert.AreEqual(user.Id, userCollectionLogic.Login(user.Username, user.Password).Id);
        }

        [TestMethod]
        public void LoginWrongUsernameTest()
        {
            user.Username = "Nickyy";
            Assert.IsNull(userCollectionLogic.Login(user.Username, user.Password));
        }

        [TestMethod]
        public void LoginWrongPasswordTest()
        {
            user.Username = "Nicky";
            user.Password = HashPassword("wrong");
            Assert.IsNull(userCollectionLogic.Login(user.Username, user.Password));
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
        }
    }
}
