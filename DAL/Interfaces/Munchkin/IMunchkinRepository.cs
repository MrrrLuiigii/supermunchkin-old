using Models.Enums;

namespace DAL.Interfaces.Munchkin
{
    public interface IMunchkinRepository
    {
        void AdjustGender(MunchkinGender gender);
        void AdjustLevel(AdjustStats direction);
        void AdjustGear(AdjustStats direction);
    }
}
