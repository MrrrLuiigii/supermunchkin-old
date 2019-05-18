using DAL.Contexts.Battles;
using DAL.Repositories;
using Interfaces.Battles;

namespace Factories
{
    public static class BattleFactory
    {
        public static IBattleRepository GetBattleRepository()
        {
            return new BattleRepository();
        }

        public static IBattleCollectionRepository GetBattleCollectionRepository()
        {
            return new BattleRepository();
        }

        public static IBattleRepository GetBattleRepositoryTest()
        {
            return new BattleRepository(new BattleContextMemory());
        }

        public static IBattleCollectionRepository GetBattleCollectionRepositoryTest()
        {
            return new BattleRepository(new BattleContextMemory());
        }
    }
}
