using Models;

namespace Interfaces.Battles
{
    public interface IBattleRepository
    {
        void AddMunchkin(Battle battle, Munchkin munchkin);
        void RemoveMunchkin(Battle battle, Munchkin munchkin);
        void AddMonster(Battle battle, Monster monster);
        void RemoveMonster(Battle battle, Monster monster);
        void AdjustBattleStatus(Battle battle);
    }
}
