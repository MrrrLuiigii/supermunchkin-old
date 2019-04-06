using System.Collections.Generic;
using DAL.Contexts.Games;
using DAL.Interfaces.Games;
using Models;
using Models.Enums;

namespace DAL.Repositories
{
    public class GameRepository : IGameRepository, IGameCollectionRepository
    {
        private IGameContext context = new GameContextMemory();

        public void AddGame(Game game)
        {
            context.AddGame(game);
        }

        public void AddMunchkin(Game game, Munchkin munchkin)
        {
            context.AddMunchkin(game, munchkin);
        }

        public void AdjustGameStatus(Game game, GameStatus status)
        {
            context.AdjustGameStatus(game, status);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return context.GetAllGames();
        }

        public Game GetGameById(int id)
        {
            return context.GetGameById(id);
        }

        public void RemoveMunchkin(Game game, Munchkin munchkin)
        {
            context.RemoveMunchkin(game, munchkin);
        }

        public void SetWinner(Game game, Munchkin munchkin)
        {
            context.SetWinner(game, munchkin);
        }
    }
}
