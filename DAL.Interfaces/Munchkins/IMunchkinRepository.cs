using Models;

namespace Interfaces.Munchkins
{
    public interface IMunchkinRepository
    {
        void AdjustMunchkin(Munchkin munchkin);
        void AdjustMunchkin(Munchkin munchkin, Battle battle);
    }
}
