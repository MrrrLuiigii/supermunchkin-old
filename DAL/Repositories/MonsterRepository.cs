using DAL.Contexts.Monsters;
using Interfaces.Monsters;

namespace DAL.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        private IMonsterContext monsterContext;

        public MonsterRepository(IMonsterContext context = null)
        {
            monsterContext = context ?? new MonsterContextSQL();
        }
    }
}
