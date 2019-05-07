using Interfaces.Users;
using Factories;
using Models;
using System.Collections.Generic;

namespace Logic.Users
{
    public class UserLogic
    {
        IUserRepository userRepository;

        public UserLogic(IUserRepository uRepository)
        {
            userRepository = uRepository = UserFactory.GetUserRepository();
        }

        public Munchkin CreateMunchkin(User user, Munchkin munchkin)
        {
            return userRepository.AddMunchkin(user, munchkin);
        }

        public void RemoveMunchkin(Munchkin munchkin)
        {
            userRepository.RemoveMunchkin(munchkin);
        }

        public IEnumerable<Munchkin> GetAllMunchkinsByUser(User user)
        {
            return userRepository.GetAllMunchkinsByUser(user);
        }

        public Munchkin GetMunchkinById(int id)
        {
            return userRepository.GetMunchkinById(id);
        }
    }
}
