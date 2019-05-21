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

        public void AddGame(User user, Game game) => userContext.AddGame(user, game);

        public Munchkin AddMunchkin(User user, Munchkin munchkin) => userContext.AddMunchkin(user, munchkin);

        public void AddUser(User user) => userContext.AddUser(user);

        public List<Munchkin> GetAllMunchkins() => userContext.GetAllMunchkins();

        public List<Munchkin> GetAllMunchkinsByUser(User user) => userContext.GetAllMunchkinsByUser(user);

        public List<User> GetAllUsers() => userContext.GetAllUsers();

        public Munchkin GetMunchkinById(int id) => userContext.GetMunchkinById(id);

        public User GetUserById(int id) => userContext.GetUserById(id);

        public void RemoveMunchkin(Munchkin munchkin) => userContext.RemoveMunchkin(munchkin);
    }
}
