using Models;
using Models.Enums;

namespace DAL.Interfaces.Munchkins
{
    public interface IMunchkinRepository
    {
        void AdjustGender(Munchkin munchkin, MunchkinGender gender);
        void AdjustLevel(Munchkin munchkin, AdjustMunchkinStats direction);
        void AdjustGear(Munchkin munchkin, AdjustMunchkinStats direction);
    }
}
