using Models;
using System.Collections.Generic;

namespace DAL.Interfaces.Games
{
    public interface IGameCollectionRepository
    {
        void AddGame(Game game);
        IEnumerable<Game> GetAllGames();
    }
}
