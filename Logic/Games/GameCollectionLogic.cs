using DAL.Interfaces.Games;
using DAL.Repositories;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Games
{
    public class GameCollectionLogic
    {
        private IGameCollectionRepository gameCollectionRepository = new GameRepository();

        public Game GetActiveGame()
        {
            List<Game> games = gameCollectionRepository.GetAllGames().ToList();

            foreach (Game g in games)
            {
                if (g.Status == Models.Enums.GameStatus.Playing)
                {
                    return g;
                }
            }

            return null;
        }

        public void AddGame(Game game)
        {
            gameCollectionRepository.AddGame(game);
        }

        public Game GetGameById(int id)
        {
            return gameCollectionRepository.GetGameById(id);
        }

    }
}
