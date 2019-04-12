using DAL.Interfaces.Games;
using DAL.Interfaces.Users;
using DAL.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Games
{
    public class GameCollectionLogic
    {
        private IUserRepository userRepository = new UserRepository();
        private IGameCollectionRepository gameCollectionRepository = new GameRepository();

        public void AddGame(Game game)
        {
            gameCollectionRepository.AddGame(game);
        }

        public Game GetGameById(int id)
        {
            IEnumerable<Game> games = gameCollectionRepository.GetAllGames();
            return games.ToList().Find(g => g.Id == id);
        }

        public Game GetGameByDateTime(DateTime dateTime)
        {
            IEnumerable<Game> games = gameCollectionRepository.GetAllGames();
            return games.ToList().Find(g => g.DatePlayed == dateTime);
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
