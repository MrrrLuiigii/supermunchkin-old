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
        public void AdjustLevelTest()
        {
            munchkinLogic.AdjustLevel(munchkin, AdjustMunchkinStats.Up);
        }

        [TestMethod]
        public void AdjustLevelTooHighTest()
        {

        }

        [TestMethod]
        public void AdjustLevelTooLowTest()
        {

        }

        [TestMethod]
        public void AdjustGearTest()
        {

        }

        [TestMethod]
        public void AdjustGearTooLowTest()
        {

        }

        [TestMethod]
        public void AdjustGenderTest()
        {

        }
    }
}
