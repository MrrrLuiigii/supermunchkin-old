using DAL.Interfaces.Munchkin;
using Models.Enums;

namespace DAL.Contexts.Munchkin
{
    public class MunchkinContextMemory : IMunchkinContext
    {
        public void AdjustGear(AdjustStats direction)
        {
            throw new System.NotImplementedException();
        }

        public void AdjustGender(MunchkinGender gender)
        {
            throw new System.NotImplementedException();
        }

        public void AdjustLevel(AdjustStats direction)
        {
            throw new System.NotImplementedException();
        }
    }
}
