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

        public Game AddGame(Game game, User user)
        {
            return gameCollectionRepository.AddGame(game, user);
        }

        public void RemoveGame(Game game)
        {
            gameCollectionRepository.RemoveGame(game);
        }

        public Game GetGameById(int id)
        {
            return gameCollectionRepository.GetGameById(id);
        }

        public List<Game> GetAllGamesByUser(User user)
        {
            return gameCollectionRepository.GetAllGamesByUser(user).ToList();
        }
    }
}
