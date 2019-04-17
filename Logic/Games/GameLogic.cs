using DAL.Interfaces.Games;
using Factories;
using Models;
using Models.Enums;

namespace Logic.Games
{
    public class GameLogic
    {
        private IGameRepository gameRepository = GameFactory.GetGameRepository();

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
