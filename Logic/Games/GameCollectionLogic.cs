using Interfaces.Games;
using Interfaces.Users;
using Factories;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Games
{
    public class GameCollectionLogic
    {
        private IUserRepository userRepository;
        private IGameCollectionRepository gameCollectionRepository;

        public GameCollectionLogic(IUserRepository uRepository = null, IGameCollectionRepository gcRepository = null)
        {
            userRepository = userRepository ?? UserFactory.GetUserRepository();
            gameCollectionRepository = gcRepository ?? GameFactory.GetGameCollectionRepository();
        }

        public Game AddGame(Game game, User user) => gameCollectionRepository.AddGame(game, user);

        public void RemoveGame(Game game) => gameCollectionRepository.RemoveGame(game);

        public Game GetGameById(int id) => gameCollectionRepository.GetGameById(id);

        public List<Game> GetAllGamesByUser(User user) => gameCollectionRepository.GetAllGamesByUser(user);
    }
}
