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

        public void CreateMunchkin(Munchkin munchkin)
        {
            userRepository.AddMunchkin(munchkin);
        }

        public void RemoveMunchkin(Munchkin munchkin)
        {
            userRepository.RemoveMunchkin(munchkin);
        }

        public Munchkin GetMunchkinById(int id)
        {
            IEnumerable<Munchkin> munchkins = userRepository.GetAllMunchkins();
            return munchkins.ToList().Find(m => m.Id == id);
        }
    }
}
