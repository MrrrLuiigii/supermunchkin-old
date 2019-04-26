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
    }
}
