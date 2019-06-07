using Logic.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Databases;
using System.Configuration;

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
            Database.SetConnectionString("server=127.0.0.1;uid=root;pwd=;database=supermunchkin");
            Database database = new Database();
            database.ExecuteStoredProcedure("ClearDatabase");

            userCollectionLogic = new UserCollectionLogic();

            user = new User("MrrrLuiigii", "admin", "nicky@gmail.com");
            userCollectionLogic.AddUser(user);
            user = userCollectionLogic.Login("MrrrLuiigii", "admin");
        }

        [TestMethod]
        public void AddUserTest()
        {
            User newUser = new User("newuser", "user", "newuser@gmail.com");
            Assert.IsTrue(userCollectionLogic.AddUser(newUser));
        }

        [TestMethod]
        public void AddUserUsernameTakenTest()
        {
            User newUser = new User("MrrrLuiigii", "user", "newuser@gmail.com");
            Assert.IsFalse(userCollectionLogic.AddUser(newUser));
        }

        [TestMethod]
        public void AddUserEmailTakenTest()
        {
            User newUser = new User("newuser", "user", "nicky@gmail.com");
            Assert.IsFalse(userCollectionLogic.AddUser(newUser));
        }

        [TestMethod]
        public void LoginTest()
        {
            User logginInUser = new User("MrrrLuiigii", "admin", "nicky@gmail.com");
            Assert.AreEqual(user.Id, userCollectionLogic.Login(logginInUser.Username, logginInUser.Password).Id);
        }

        [TestMethod]
        public void LoginWrongUsernameTest()
        {
            User logginInUser = new User("wrong", "admin", "nicky@gmail.com");
            Assert.IsNull(userCollectionLogic.Login(logginInUser.Username, logginInUser.Password));
        }

        [TestMethod]
        public void LoginWrongPasswordTest()
        {
            User logginInUser = new User("MrrrLuiigii", "wrong", "nicky@gmail.com");
            Assert.IsNull(userCollectionLogic.Login(user.Username, user.Password));
        }
    }
}
