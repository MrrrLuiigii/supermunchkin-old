using DAL.Interfaces.Games;
using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Games
{
    public class GameCollectionLogic
    {
        private IGameCollectionRepository gameCollectionRepository = new GameRepository();

        public void AddGame(Game game)
        {
            gameCollectionRepository.AddGame(game);
        }

        public Game GetGameById(int id)
        {
            return gameCollectionRepository.GetGameById(id);
        }

        public Game GetGameByDateTime(DateTime dateTime)
        {
            IEnumerable<Game> games = gameCollectionRepository.GetAllGames();
            return games.ToList().Find(x => x.DatePlayed == dateTime);
        }

    }
}
