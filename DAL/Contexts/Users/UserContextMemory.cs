using System.Collections.Generic;
using Interfaces.Users;
using Databases;
using Models;

namespace DAL.Contexts.Users
{
    public class UserContextMemory : IUserContext
    {
        private Memory memory = new Memory();

        public void AddMunchkin(User user, Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        public void AddUser(User user)
        {
            //Add user
        }

        public IEnumerable<Munchkin> GetAllMunchkins()
        {
            return memory.GetAllMunchkins();
        }

        public IEnumerable<Munchkin> GetAllMunchkinsByUser(User user)
        {
            //Get all munchkins by user
            return null;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return memory.GetAllUsers();
        }

        public Munchkin GetMunchkinById(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return memory.GetUserById(id);
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
