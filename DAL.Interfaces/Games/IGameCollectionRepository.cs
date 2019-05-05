using Models;
using System.Collections.Generic;

namespace Interfaces.Games
{
    public interface IGameCollectionRepository
    {
        void AddGame(Game game, User user);
        void RemoveGame(Game game);
        IEnumerable<Game> GetAllGames();
        IEnumerable<Game> GetAllGamesByUser(User user);
    }
}
