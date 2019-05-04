using Interfaces.Games;
using Interfaces.Users;
using Factories;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Games
{
    public class GameCollectionLogic
    {
        private IUserRepository userRepository = UserFactory.GetUserRepository();
        private IGameCollectionRepository gameCollectionRepository = GameFactory.GetGameCollectionRepository();

        public Game AddGame(Game game)
        {
            IEnumerable<Game> games = gameCollectionRepository.GetAllGames();

            while (games.ToList().Find(g => g.DateTimePlayed == game.DateTimePlayed && g.Status == game.Status) != null)
            {
                game.DateTimePlayed = game.DateTimePlayed.AddSeconds(1);
            }

            gameCollectionRepository.AddGame(game);
            return GetGameByDateTimeAndStatus(game.DateTimePlayed, game.Status);
        }

        public void RemoveGame(Game game)
        {
            gameCollectionRepository.RemoveGame(game);
        }

        public Game GetGameById(int id)
        {
            IEnumerable<Game> games = gameCollectionRepository.GetAllGames();
            return games.ToList().Find(g => g.Id == id);
        }

        public Game GetGameByDateTimeAndStatus(DateTime dateTime, GameStatus status)
        {
            IEnumerable<Game> games = gameCollectionRepository.GetAllGames();
            return games.ToList().Find(g => g.DateTimePlayed == dateTime && g.Status == status);
        }

        public List<Game> GetAllGamesByUser(User user)
        {
            return gameCollectionRepository.GetAllGamesByUser(user).ToList();
        }
    }
}
