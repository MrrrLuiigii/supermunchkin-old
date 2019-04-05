using Models.Interfaces;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IGameCollectionRepository
    {
        void AddGame(IGame game);
        IEnumerable<IGame> GetAllGames();
        IGame GetGameById(int id);
    }
}
