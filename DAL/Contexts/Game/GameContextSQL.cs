using System.Collections.Generic;
using DAL.Interfaces.Game;
using Models.Enums;
using Models.Interfaces;

namespace DAL.Contexts.Game
{
    public class GameContextSQL : IGameContext
    {
        public void AddGame(IGame game)
        {
            throw new System.NotImplementedException();
        }

        public void AddMunchkin(IMunchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        public void AdjustGameStatus(GameStatus status)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IGame> GetAllGames()
        {
            throw new System.NotImplementedException();
        }

        public IGame GetGameById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMunchkin(IMunchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        public void SetWinner(IMunchkin munchkin)
        {
            throw new System.NotImplementedException();
        }
    }
}
