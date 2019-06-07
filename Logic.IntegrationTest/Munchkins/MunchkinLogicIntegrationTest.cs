using Logic.Munchkins;
using Logic.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Models.Enums;
using Databases;

namespace Logic.Test.Munchkins
{
    [TestClass]
    public class MunchkinLogicIntegrationTest
    {
        MunchkinLogic munchkinLogic;
        Munchkin munchkin;

        [TestInitialize]
        public void TestInitialize()
        {
            Database.SetConnectionString("server=127.0.0.1;uid=root;pwd=;database=supermunchkin");
            Database database = new Database();
            database.ExecuteStoredProcedure("ClearDatabase");

            UserLogic userLogic = new UserLogic();
            UserCollectionLogic userCollectionLogic = new UserCollectionLogic();            

            User user = new User("MrrrLuiigii", "admin", "nicky@gmail.com");
            userCollectionLogic.AddUser(user);
            user = userCollectionLogic.Login("MrrrLuiigii", "admin");

            munchkin = new Munchkin(1, user.Username, MunchkinGender.Male, 5, 5);
            munchkin = userLogic.CreateMunchkin(user, munchkin);
            
            munchkinLogic = new MunchkinLogic();
        }

        [TestMethod]
        public void AdjustLevelUpTest()
        {
            munchkinLogic.AdjustLevel(munchkin, AdjustStats.Up);
            Assert.AreEqual(6, munchkin.Level);
        }

        [TestMethod]
        public void AdjustLevelDownTest()
        {
            munchkinLogic.AdjustLevel(munchkin, AdjustStats.Down);
            Assert.AreEqual(4, munchkin.Level);
        }

        [TestMethod]
        public void AdjustLevelTooHighTest()
        {
            munchkin.Level = 10;
            munchkinLogic.AdjustLevel(munchkin, AdjustStats.Up);
            Assert.AreEqual(10, munchkin.Level);
        }

        [TestMethod]
        public void AdjustLevelTooLowTest()
        {
            munchkin.Level = 1;
            munchkinLogic.AdjustLevel(munchkin, AdjustStats.Down);
            Assert.AreEqual(1, munchkin.Level);
        }

        [TestMethod]
        public void AdjustGearUpTest()
        {
            munchkinLogic.AdjustGear(munchkin, AdjustStats.Up);
            Assert.AreEqual(6, munchkin.Gear);
        }

        [TestMethod]
        public void AdjustGearDownTest()
        {
            munchkinLogic.AdjustGear(munchkin, AdjustStats.Down);
            Assert.AreEqual(4, munchkin.Gear);
        }

        [TestMethod]
        public void AdjustGearTooLowTest()
        {
            munchkin.Gear = 0;
            munchkinLogic.AdjustGear(munchkin, AdjustStats.Down);
            Assert.AreEqual(0, munchkin.Gear);
        }

        [TestMethod]
        public void AdjustGenderMaleToFemaleTest()
        {
            munchkinLogic.AdjustGender(munchkin);
            Assert.AreEqual(MunchkinGender.Female, munchkin.Gender);
        }

        [TestMethod]
        public void AdjustGenderFemaleToMaleTest()
        {
            munchkin.Gender = MunchkinGender.Female;
            munchkinLogic.AdjustGender(munchkin);
            Assert.AreEqual(MunchkinGender.Male,  munchkin.Gender);
        }
    }
}
