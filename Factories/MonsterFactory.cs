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

        public static IMonsterCollectionRepository GetMonsterCollectionRepository()
        {
            return new MonsterRepository();
        }

        public static IMonsterRepository GetMonsterRepositoryTest()
        {
            return new MonsterRepository(new MonsterContextMemory());
        }

        public static IMonsterCollectionRepository GetMonsterCollectionRepositoryTest()
        {
            return new MonsterRepository(new MonsterContextMemory());
        }
    }
}
