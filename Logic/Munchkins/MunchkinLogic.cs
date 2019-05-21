using Interfaces.Munchkins;
using Factories;
using Models;
using Models.Enums;

namespace Logic.Munchkins
{
    public class MunchkinLogic
    {
        IMunchkinRepository munchkinRepository;

        public MunchkinLogic(IMunchkinRepository mRepository = null)
        {
            munchkinRepository = mRepository ?? MunchkinFactory.GetMunchkinRepository();
        }

        public void AdjustLevel(Munchkin munchkin, AdjustStats direction)
        {
            if (direction == AdjustStats.Up)
            {
                if (munchkin.Level < 10)
                {
                    munchkin.Level += 1;
                }
                else
                {
                    munchkin.Level = 10;
                }
            }
            else if (direction == AdjustStats.Down)
            {
                if (munchkin.Level > 1)
                {
                    munchkin.Level -= 1;
                }
                else
                {
                    munchkin.Level = 1;
                }
            }

            munchkinRepository.AdjustMunchkin(munchkin);
        }

        public void AdjustGear(Munchkin munchkin, AdjustStats direction)
        {
            if (direction == AdjustStats.Up)
            {
                munchkin.Gear += 1;
            }
            else if (direction == AdjustStats.Down)
            {
                if (munchkin.Gear > 0)
                {
                    munchkin.Gear -= 1;
                }
                else
                {
                    munchkin.Gear = 0;
                }
            }

            munchkinRepository.AdjustMunchkin(munchkin);
        }

        public void AdjustGender(Munchkin munchkin)
        {
            MunchkinGender gender = MunchkinGender.Male;

            if(munchkin.Gender == MunchkinGender.Male)
            {
                gender = MunchkinGender.Female;
            }

            munchkin.Gender = gender;
            munchkinRepository.AdjustMunchkin(munchkin);
        }
    }
}
