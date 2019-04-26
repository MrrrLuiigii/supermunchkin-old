using Interfaces.Users;
using Factories;
using Models;
using System.Linq;

namespace Logic.Users
{
    public class UserLogic
    {
        IUserRepository userRepository = UserFactory.GetUserRepository();

        public Munchkin CreateMunchkin(User user, Munchkin munchkin)
        {
            userRepository.AddMunchkin(user, munchkin);
            return GetLatestMunchkin(user);
        }

        public void RemoveMunchkin(Munchkin munchkin)
        {
            userRepository.RemoveMunchkin(munchkin);
        }

        private Munchkin GetLatestMunchkin(User user)
        {
            Munchkin munchkin = userRepository.GetAllMunchkins().ToList().Where(m => m.Name == user.Username).OrderByDescending(m => m.Id).FirstOrDefault();
            return munchkin;
        }

        public Munchkin GetMunchkinById(int id)
        {
            return userRepository.GetAllMunchkins().ToList().Find(m => m.Id == id);
        }
    }
}
