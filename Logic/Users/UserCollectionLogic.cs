using DAL.Interfaces.Users;
using DAL.Repositories;
using Models;
using System.Collections.Generic;

namespace Logic.Users
{
    public class UserCollectionLogic
    {
        IUserCollectionRepository userRepo = new UserRepository();

        public void AddUser(User user)
        {
            userRepo.AddUser(user);
        }

        public User GetUserById(int id)
        {
            return userRepo.GetUserById(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userRepo.GetAllUsers();
        }
    }
}
