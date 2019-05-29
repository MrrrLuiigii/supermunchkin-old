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

        public void AddBattle(Game game, Battle battle) => gameContext.AddBattle(game, battle);

        public Game AddGame(Game game, User user) => gameContext.AddGame(game, user);

        public void AddMunchkin(Game game, Munchkin munchkin) => gameContext.AddMunchkin(game, munchkin);

        public void AdjustGameStatus(Game game, GameStatus status) => gameContext.AdjustGameStatus(game, status);

        public List<Battle> GetAllBattlesByGame(Game game) => gameContext.GetAllBattlesByGame(game);

        public List<Battle> GetAllBattlesByMunchkin(Munchkin munchkin) => gameContext.GetAllBattlesByMunchkin(munchkin);

        public List<Game> GetAllGames() => gameContext.GetAllGames();

        public List<Game> GetAllGamesByUser(User user) => gameContext.GetAllGamesByUser(user);

        public Battle GetBattleById(int id) => gameContext.GetBattleById(id);

        public Game GetGameById(int id) => gameContext.GetGameById(id);

        public void RemoveBattle(Game game, Battle battle) => gameContext.RemoveBattle(game, battle);

        public void RemoveGame(Game game) => gameContext.RemoveGame(game);

        public void RemoveMunchkin(Game game, Munchkin munchkin) => gameContext.RemoveMunchkin(game, munchkin);

        public void SetWinner(Game game, Munchkin munchkin) => gameContext.SetWinner(game, munchkin);
    }
}
