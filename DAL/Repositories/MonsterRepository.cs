using System.Collections.Generic;
using DAL.Contexts.Monsters;
using Interfaces.Monsters;
using Models;

namespace DAL.Repositories
{
    public class MonsterRepository : IMonsterRepository, IMonsterCollectionRepository
    {
        private IMonsterContext monsterContext;

        public MonsterRepository(IMonsterContext context = null)
        {
            monsterContext = context ?? new MonsterContextSQL();
        }

        public void AdjustMonster(Monster monster) => monsterContext.AdjustMonster(monster);

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
