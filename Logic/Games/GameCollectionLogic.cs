using DAL.Interfaces.Games;
using DAL.Repositories;
using Models;

namespace Logic.Games
{
    public class GameCollectionLogic
    {
        private IGameCollectionRepository gameCollectionRepository = new GameRepository();

        public void AddGame(Game game)
        {
            gameCollectionRepository.AddGame(game);
        }
    }
}
