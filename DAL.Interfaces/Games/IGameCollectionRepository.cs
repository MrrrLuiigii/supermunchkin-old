using Models;
using System.Collections.Generic;

namespace Interfaces.Games
{
    public interface IGameCollectionRepository
    {
        void AddGame(Game game);
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetAllGamesByUser(User user);
    }
}
