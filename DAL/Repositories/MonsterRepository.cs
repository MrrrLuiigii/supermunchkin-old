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
    }
}
