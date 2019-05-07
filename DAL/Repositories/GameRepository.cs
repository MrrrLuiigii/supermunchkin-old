using System.Collections.Generic;
using DAL.Contexts.Games;
using Interfaces.Games;
using Models;
using Models.Enums;

namespace DAL.Repositories
{
    public class GameRepository : IGameRepository, IGameCollectionRepository
    {
        private IGameContext gameContext;

        public GameRepository(IGameContext context = null)
        {
            gameContext = context ?? new GameContextSQL();
        }

        public Game AddGame(Game game, User user)
        {
            return gameContext.AddGame(game, user);
        }

        public void AddMunchkin(Game game, Munchkin munchkin)
        {
            gameContext.AddMunchkin(game, munchkin);
        }

        public void AdjustGameStatus(Game game, GameStatus status)
        {
            gameContext.AdjustGameStatus(game, status);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return gameContext.GetAllGames();
        }

        public IEnumerable<Game> GetAllGamesByUser(User user)
        {
            return gameContext.GetAllGamesByUser(user);
        }

        public Game GetGameById(int id)
        {
            return gameContext.GetGameById(id);
        }

        public void RemoveGame(Game game)
        {
            gameContext.RemoveGame(game);
        }

        public void RemoveMunchkin(Game game, Munchkin munchkin)
        {
            gameContext.RemoveMunchkin(game, munchkin);
        }

        public void SetWinner(Game game, Munchkin munchkin)
        {
            gameContext.SetWinner(game, munchkin);
        }
    }
}
