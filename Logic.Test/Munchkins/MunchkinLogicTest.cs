using Factories;
using Logic.Munchkins;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Models.Enums;

namespace Logic.Test.Munchkins
{
    [TestClass]
    public class MunchkinLogicTest
    {
        MunchkinLogic munchkinLogic;
        Munchkin munchkin;

        [TestInitialize]
        public void TestInitialize()
        {
            munchkin = new Munchkin(1, "MrrrLuiigii", MunchkinGender.Male, 5, 5);
            munchkinLogic = new MunchkinLogic(MunchkinFactory.GetMunchkinRepositoryTest());
        }

        [TestMethod]
        public void AdjustLevelUpTest()
        {
            munchkinLogic.AdjustLevel(munchkin, AdjustMunchkinStats.Up);
            Assert.AreEqual(munchkin.Level, 6);
        }

        [TestMethod]
        public void AdjustLevelDownTest()
        {
            munchkinLogic.AdjustLevel(munchkin, AdjustMunchkinStats.Down);
            Assert.AreEqual(munchkin.Level, 4);
        }

        [TestMethod]
        public void AdjustLevelTooHighTest()
        {
            munchkin.Level = 10;
            munchkinLogic.AdjustLevel(munchkin, AdjustMunchkinStats.Up);
            Assert.AreEqual(munchkin.Level, 10);
        }

        [TestMethod]
        public void AdjustLevelTooLowTest()
        {
            munchkin.Level = 0;
            munchkinLogic.AdjustLevel(munchkin, AdjustMunchkinStats.Down);
            Assert.AreEqual(munchkin.Level, 0);
        }

        [TestMethod]
        public void AdjustGearUpTest()
        {
            munchkinLogic.AdjustGear(munchkin, AdjustMunchkinStats.Up);
            Assert.AreEqual(munchkin.Gear, 6);
        }

        [TestMethod]
        public void AdjustGearDownTest()
        {
            munchkinLogic.AdjustGear(munchkin, AdjustMunchkinStats.Down);
            Assert.AreEqual(munchkin.Gear, 4);
        }

        [TestMethod]
        public void AdjustGearTooLowTest()
        {
            munchkin.Gear = 0;
            munchkinLogic.AdjustGear(munchkin, AdjustMunchkinStats.Down);
            Assert.AreEqual(munchkin.Gear, 0);
        }

        [TestMethod]
        public void AdjustGenderMaleToFemaleTest()
        {
            munchkinLogic.AdjustGender(munchkin);
            Assert.AreEqual(munchkin.Gender, MunchkinGender.Female);
        }

        [TestMethod]
        public void AdjustGenderFemaleToMaleTest()
        {
            munchkin.Gender = MunchkinGender.Female;
            munchkinLogic.AdjustGender(munchkin);
            Assert.AreEqual(munchkin.Gender, MunchkinGender.Male);
        }
    }
}
