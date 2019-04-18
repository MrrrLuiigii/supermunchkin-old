using DAL.Interfaces.Users;
using Factories;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Users
{
    public class UserLogic
    {
        IUserRepository userRepository = UserFactory.GetUserRepository();

        public void CreateMunchkin(User user, Munchkin munchkin)
        {
            userRepository.AddMunchkin(user, munchkin);
        }

        public void RemoveMunchkin(User user, Munchkin munchkin)
        {
            userRepository.RemoveMunchkin(user, munchkin);
        }

        public Munchkin GetLatestMunchkin()
        {
            //Alexander pls
            int highestId = userRepository.GetAllMunchkins().ToList().Max(m => m.Id);
            return GetMunchkinById(highestId);
        }

        public Munchkin GetMunchkinById(int id)
        {
            return userRepository.GetAllMunchkins().ToList().Find(m => m.Id == id);
        }
    }
}
