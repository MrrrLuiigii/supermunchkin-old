using Interfaces.Games;
using DAL.Repositories;

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

        public static IGameRepository GetGameRepositoryTest(IGameContext context)
        {
            return new GameRepository(context);
        }

        public static IGameCollectionRepository GetGameCollectionRepositoryTest(IGameContext context)
        {
            return new GameRepository(context);
        }
    }
}
