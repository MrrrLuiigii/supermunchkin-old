using DAL.Interfaces.Games;
using DAL.Repositories;
using Models;
using Models.Enums;

namespace Logic.Games
{
    public class GameLogic
    {
        private IGameRepository gameRepository = new GameRepository();

        public void SetWinner(Game game, Munchkin munchkin)
        {
            gameRepository.SetWinner(game, munchkin);
        }

        public void AdjustGameStatus(Game game, GameStatus status)
        {
            gameRepository.AdjustGameStatus(game, status);
        }
    }
}
