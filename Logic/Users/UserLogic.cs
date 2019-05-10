using Interfaces.Users;
using Factories;
using Models;
using System.Collections.Generic;

namespace Logic.Users
{
    public class UserLogic
    {
        IUserRepository userRepository;

        public UserLogic(IUserRepository uRepository = null)
        {
            userRepository = uRepository ?? UserFactory.GetUserRepository();
        }

        public Munchkin CreateMunchkin(User user, Munchkin munchkin) =>  userRepository.AddMunchkin(user, munchkin);

        public void RemoveMunchkin(Munchkin munchkin) => userRepository.RemoveMunchkin(munchkin);

        public IEnumerable<Munchkin> GetAllMunchkinsByUser(User user) => userRepository.GetAllMunchkinsByUser(user);

        public Munchkin GetMunchkinById(int id) => userRepository.GetMunchkinById(id);
    }
}
