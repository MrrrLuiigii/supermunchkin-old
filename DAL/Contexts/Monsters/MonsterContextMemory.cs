using System.Collections.Generic;
using Interfaces.Monsters;
using Models;

namespace DAL.Contexts.Monsters
{
    public class MonsterContextMemory : IMonsterContext
    {
        public void AdjustMonster(Monster monster, Battle battle)
        {
            throw new System.NotImplementedException();
        }

        public int CreateMonster(Monster monster)
        {
            throw new System.NotImplementedException();
        }

        public List<Monster> GetAllMonstersByBattle(Battle battle)
        {
            throw new System.NotImplementedException();
        }

        public Monster GetMonsterById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMonster(Monster monster)
        {
            throw new System.NotImplementedException();
        }
    }
}
