using System.Collections.Generic;
using Interfaces.Users;
using Databases;
using Models;

namespace DAL.Contexts.Users
{
    public class UserContextMemory : IUserContext
    {
        private Memory memory = new Memory();

        public Munchkin AddMunchkin(User user, Munchkin munchkin)
        {
            return memory.AddMunchkin(user, munchkin);
        }

        public void AddUser(User user)
        {
            memory.AddUser(user);
        }

        public List<Munchkin> GetAllMunchkins()
        {
            return memory.GetAllMunchkins();
        }

        public List<Munchkin> GetAllMunchkinsByUser(User user)
        {
            return memory.GetMunchkinsByUser(user);
        }

        public List<User> GetAllUsers()
        {
            return memory.GetAllUsers();
        }

        public Munchkin GetMunchkinById(int id)
        {
            return memory.GetMunchkinById(id);
        }

        public User GetUserById(int id)
        {
            return memory.GetUserById(id);
        }

        public void RemoveMunchkin(Munchkin munchkin)
        {
            memory.RemoveMunchkin(munchkin);
        }
    }
}
