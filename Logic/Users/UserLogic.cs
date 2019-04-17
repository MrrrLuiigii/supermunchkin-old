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

        public Munchkin GetMunchkinById(int id)
        {
            IEnumerable<Munchkin> munchkins = userRepository.GetAllMunchkins();
            return munchkins.ToList().Find(m => m.Id == id);
        }
    }
}
