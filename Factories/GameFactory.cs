using Interfaces.Games;
using DAL.Repositories;
using DAL.Contexts.Games;

namespace Factories
{
    public static class GameFactory
    {
        public static IGameRepository GetGameRepository()
        {
            return new GameRepository();
        }

        public static IGameCollectionRepository GetGameCollectionRepository()
        {
            return new GameRepository();
        }

        public static IGameRepository GetGameRepositoryTest()
        {
            return new GameRepository(new GameContextMemory());
        }

        public static IGameCollectionRepository GetGameCollectionRepositoryTest()
        {
            return new GameRepository(new GameContextMemory());
        }
    }
}
