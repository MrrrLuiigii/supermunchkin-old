using DAL.Contexts.Munchkins;
using DAL.Interfaces.Munchkins;
using Models;
using Models.Enums;

namespace DAL.Repositories
{
    public class MunchkinRepository : IMunchkinRepository
    {
        private IMunchkinContext munchkinContext = new MunchkinContextMemory();

        public void AdjustGear(Munchkin munchkin, AdjustMunchkinStats direction)
        {
            munchkinContext.AdjustGear(munchkin, direction);
        }

        public void AdjustGender(Munchkin munchkin, MunchkinGender gender)
        {
            munchkinContext.AdjustGender(munchkin, gender);
        }

        public void AdjustLevel(Munchkin munchkin, AdjustMunchkinStats direction)
        {
            munchkinContext.AdjustLevel(munchkin, direction);
        }
    }
}
