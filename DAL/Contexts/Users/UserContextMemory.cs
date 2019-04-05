using System.Collections.Generic;
using DAL.Interfaces.Users;
using Database;
using Models;

namespace DAL.Contexts.Users
{
    public class UserContextMemory : IUserContext
    {
        private Memory memory = new Memory();

        public void AddMunchkin(Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        public void AddUser(User user)
        {
            //Add user
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

        public void RemoveMunchkin(Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }
    }
}
