using DAL.Contexts.Monsters;
using DAL.Repositories;
using Interfaces.Monsters;

namespace Factories
{
    public static class MonsterFactory
    {
        public static IMonsterRepository GetMonsterRepository()
        {
            return new MonsterRepository();
        }

        public static IMonsterRepository GetMonsterRepositoryTest()
        {
            return new MonsterRepository(new MonsterContextMemory());
        }
    }
}
