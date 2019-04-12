using DAL.Interfaces.Users;
using DAL.Repositories;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Users
{
    public class UserLogic
    {
        IUserRepository userRepository = new UserRepository();

        public Munchkin GetMunchkinById(int id)
        {
            IEnumerable<Munchkin> munchkins = userRepository.GetAllMunchkins();
            return munchkins.ToList().Find(m => m.Id == id);
        }
    }
}
