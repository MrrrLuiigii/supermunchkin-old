using System.Collections.Generic;
using DAL.Interfaces.User;

namespace DAL.Contexts.User
{
    public class UserContextSQL : IUserContext
    {
        public void AddMunchkin(Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Munchkin> GetAllMunchkins()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Munchkin GetMunchkinById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMunchkin(Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }
    }
}
