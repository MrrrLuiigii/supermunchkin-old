using System.Collections.Generic;
using DAL.Interfaces.Users;
using DAL.Contexts.Users;
using Models;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository, IUserCollectionRepository
    {
        private IUserContext userContext = new UserContextSQL();

        public void AddMunchkin(User user, Munchkin munchkin)
        {
            userContext.AddMunchkin(user, munchkin);
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

        public void RemoveMunchkin(Munchkin munchkin)
        {
            userContext.RemoveMunchkin(munchkin);
        }
    }
}
