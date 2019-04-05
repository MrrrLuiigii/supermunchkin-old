using System.Collections.Generic;
using DAL.Interfaces.Users;
using DAL.Contexts.Users;
using Models;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository, IUserCollectionRepository
    {
        private IUserContext userContext = new UserContextMemory();

        public void AddMunchkin(Munchkin munchkin)
        {
            userContext.AddMunchkin(munchkin);
        }

        public void AddUser(User user)
        {
            userContext.AddUser(user);
        }

        public IEnumerable<Munchkin> GetAllMunchkins()
        {
            return userContext.GetAllMunchkins();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userContext.GetAllUsers();
        }

        public Munchkin GetMunchkinById(int id)
        {
            return userContext.GetMunchkinById(id);
        }

        public User GetUserById(int id)
        {
            return userContext.GetUserById(id);
        }

        public void RemoveMunchkin(Munchkin munchkin)
        {
            userContext.RemoveMunchkin(munchkin);
        }
    }
}
