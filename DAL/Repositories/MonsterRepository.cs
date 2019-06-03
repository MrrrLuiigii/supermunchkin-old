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

        public void AdjustMonster(Monster monster, Battle battle) => monsterContext.AdjustMonster(monster, battle);

        public int CreateMonster(Monster monster) => monsterContext.CreateMonster(monster);

        public List<Monster> GetAllMonstersByBattle(Battle battle) => monsterContext.GetAllMonstersByBattle(battle);

        public Monster GetMonsterById(int id) => monsterContext.GetMonsterById(id);

        public void RemoveMonster(Monster monster) => monsterContext.RemoveMonster(monster);
    }
}
