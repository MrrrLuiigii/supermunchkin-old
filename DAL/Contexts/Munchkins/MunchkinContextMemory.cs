using DAL.Interfaces.Munchkins;
using Database;
using Models;
using Models.Enums;

namespace DAL.Contexts.Munchkins
{
    public class MunchkinContextMemory : IMunchkinContext
    {
        Memory memory = new Memory();

        public void AdjustGear(Munchkin munchkin, AdjustMunchkinStats direction)
        {
            //Adjust Gear
        }

        public void AdjustGender(Munchkin munchkin, MunchkinGender gender)
        {
            //Adjust Gender
        }

        public void AdjustLevel(Munchkin munchkin, AdjustMunchkinStats direction)
        {
            //Adjust Level
        }
    }
}
