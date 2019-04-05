using System.Collections.Generic;
using DAL.Interfaces.Games;
using Models;
using Models.Enums;

namespace DAL.Repos
{
    public class GameRepository : IGameRepository, IGameCollectionRepository
    {
        public void AddGame(Game game)
        {
            throw new System.NotImplementedException();
        }

        public void AddMunchkin(Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        public void AdjustGameStatus(GameStatus status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Game> GetAllGames()
        {
            throw new System.NotImplementedException();
        }

        public Game GetGameById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMunchkin(Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        public void SetWinner(Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }
    }
}
