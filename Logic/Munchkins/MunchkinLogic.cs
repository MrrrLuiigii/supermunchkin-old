using Interfaces.Munchkins;
using Factories;
using Models;
using Models.Enums;

namespace Logic.Munchkins
{
    public class MunchkinLogic
    {
        IMunchkinRepository munchkinRepository = MunchkinFactory.GetMunchkinRepository();

        public bool AdjustLevel(Munchkin munchkin, AdjustMunchkinStats direction)
        {
            if (direction == AdjustMunchkinStats.Up)
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
            else if (direction == AdjustMunchkinStats.Down)
            {
                if (munchkin.Level > 0)
                {
                    munchkin.Level -= 1;
                }
                else
                {
                    munchkin.Level = 0;
                }
            }

            munchkinRepository.AdjustMunchkin(munchkin);
            return CheckWin(munchkin);
        }

        private bool CheckWin(Munchkin munchkin)
        {
            if (munchkin.Level == 10)
            {
                return true;
            }

            return false;
        }

        public void AdjustGear(Munchkin munchkin, AdjustMunchkinStats direction)
        {
            if (direction == AdjustMunchkinStats.Up)
            {
                munchkin.Gear += 1;
            }
            else if (direction == AdjustMunchkinStats.Down)
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
