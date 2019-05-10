using System.Collections.Generic;
using Interfaces.Users;
using DAL.Contexts.Users;
using Models;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository, IUserCollectionRepository
    {
        private IUserContext userContext;

        public UserRepository(IUserContext context = null)
        {
            userContext = context ?? new UserContextSQL();
        }

        public Munchkin AddMunchkin(User user, Munchkin munchkin)
        {
            return userContext.AddMunchkin(user, munchkin);
        }

        public void AddUser(User user)
        {
            userContext.AddUser(user);
        }

        public IEnumerable<Munchkin> GetAllMunchkins()
        {
            return userContext.GetAllMunchkins();
        }

        public IEnumerable<Munchkin> GetAllMunchkinsByUser(User user)
        {
            return userContext.GetAllMunchkinsByUser(user);
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
