using Models;

namespace Interfaces.Monsters
{
    public interface IMonsterRepository
    {
        void AdjustMonster(Monster monster, Battle battle);
    }
}
