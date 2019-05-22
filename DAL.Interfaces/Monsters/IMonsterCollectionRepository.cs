using Models;
using System.Collections.Generic;

namespace Interfaces.Monsters
{
    public interface IMonsterCollectionRepository
    {
        int CreateMonster(Monster monster);
        void RemoveMonster(Monster monster);
        List<Monster> GetAllMonstersByBattle(Battle battle);
        Monster GetMonsterById(int id);
    }
}
