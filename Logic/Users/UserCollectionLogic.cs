using DAL.Interfaces.Users;
using DAL.Repositories;
using Models;
using System.Collections.Generic;

namespace Logic.Users
{
    public class UserCollectionLogic
    {
        IUserCollectionRepository userRepo = new UserRepository();

        public bool AddUser(User user)
        {
            IEnumerable<User> users = GetAllUsers();

            foreach (User u in users)
            {
                if (u.Username == user.Username || u.Email == user.Email)
                {
                    return false;
                }
            }

            userRepo.AddUser(user);
            return true;
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
