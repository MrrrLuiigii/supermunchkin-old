using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGameCollectionRepository
    {
        void AddGame(Game game);
        IEnumerable<Game> GetAllGames();
        Game GetGameById(int id);
    }
}
