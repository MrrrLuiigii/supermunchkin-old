using Interfaces.Users;
using Factories;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Users
{
    public class UserCollectionLogic
    {
        IUserCollectionRepository userCollectionRepository;

        public UserCollectionLogic(IUserCollectionRepository ucRepository = null)
        {
            userCollectionRepository = ucRepository ?? UserFactory.GetUserCollectionRepository();
        }

        public bool AddUser(User user)
        {
            List<User> users = GetAllUsers().ToList();
            
            if (users.Find(u => u.Username == user.Username || u.Email == user.Email) != null)
            {
                return false;
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt());
            userCollectionRepository.AddUser(user);
            return true;
        }

        public User Login(string username, string password)
        {
            User user = GetAllUsers().ToList().Find(u => u.Username == username);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return user;
            }

            return null;
        }

        public User GetUserById(int id) => userCollectionRepository.GetUserById(id);

        public IEnumerable<User> GetAllUsers() => userCollectionRepository.GetAllUsers();
    }
}
