using Models.Enums;

namespace DAL.Interfaces.Munchkins
{
    public interface IMunchkinRepository
    {
        void AdjustGender(MunchkinGender gender);
        void AdjustLevel(AdjustMunchkinStats direction);
        void AdjustGear(AdjustMunchkinStats direction);
    }
}
