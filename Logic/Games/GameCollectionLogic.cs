using DAL.Interfaces.Games;
using DAL.Interfaces.Users;
using DAL.Repositories;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Games
{
    public class GameCollectionLogic
    {
        private IUserRepository userRepository = new UserRepository();
        private IGameCollectionRepository gameCollectionRepository = new GameRepository();

        public Game AddGame(Game game)
        {
            IEnumerable<Game> games = gameCollectionRepository.GetAllGames();

            while (games.ToList().Find(g => g.DatePlayed == game.DatePlayed && g.Status == game.Status) != null)
            {
                game.DatePlayed = game.DatePlayed.AddSeconds(1);
            }

            gameCollectionRepository.AddGame(game);
            return GetGameByDateTimeAndStatus(game.DatePlayed, game.Status);
        }

        public Game GetGameById(int id)
        {
            IEnumerable<Game> games = gameCollectionRepository.GetAllGames();
            return games.ToList().Find(g => g.Id == id);
        }

        public Game GetGameByDateTimeAndStatus(DateTime dateTime, GameStatus status)
        {
            IEnumerable<Game> games = gameCollectionRepository.GetAllGames();
            return games.ToList().Find(g => g.DatePlayed == dateTime && g.Status == status);
        }

        public List<Game> GetAllGamesByUser(User user)
        {
            List<Game> games = gameCollectionRepository.GetAllGames().ToList();
            List<Game> userGames = new List<Game>();

            foreach (Game game in games)
            {
                foreach (Munchkin munchkin in user.Munchkins)
                {
                    if (game.Munchkins.Find(m => m.Id == munchkin.Id) != null)
                    {
                        userGames.Add(game);
                        break;
                    }
                }
            }

            return userGames;
        }

    }
}
