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
            munchkin.Level = 0;
            munchkinLogic.AdjustLevel(munchkin, AdjustStats.Down);
            Assert.AreEqual(0, munchkin.Level);
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
