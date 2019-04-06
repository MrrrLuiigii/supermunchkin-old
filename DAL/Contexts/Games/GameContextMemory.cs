using System.Collections.Generic;
using DAL.Interfaces.Games;
using Database;
using Models;
using Models.Enums;

namespace DAL.Contexts.Games
{
    public class GameContextMemory : IGameContext
    {
        private Memory memory = new Memory();

        public void AddGame(Game game)
        {
            //Add game
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