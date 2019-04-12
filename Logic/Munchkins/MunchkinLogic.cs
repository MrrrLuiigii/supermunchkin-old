using DAL.Interfaces.Munchkins;
using DAL.Repositories;
using Models;
using Models.Enums;

namespace Logic.Munchkins
{
    public class MunchkinLogic
    {
        IMunchkinRepository munchkinRepository = new MunchkinRepository();

        public void AdjustLevel(Munchkin munchkin, AdjustMunchkinStats direction)
        {
            munchkinRepository.AdjustLevel(munchkin, direction);
        }

        public void AdjustGear(Munchkin munchkin, AdjustMunchkinStats direction)
        {
            munchkinRepository.AdjustGear(munchkin, direction);
        }

        public void AdjustGender(Munchkin munchkin, MunchkinGender gender)
        {
            munchkinRepository.AdjustGender(munchkin, gender);
        }
    }
}
