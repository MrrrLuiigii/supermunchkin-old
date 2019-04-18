using System.Collections.Generic;
using DAL.Interfaces.Users;
using Database;
using Models;

namespace DAL.Contexts.Users
{
    public class UserContextSQL : IUserContext
    {
        private CRUD crud = new CRUD();

        public void AddMunchkin(User user, Munchkin munchkin)
        {
            string table = "munchkin";
            string[] arguments = { "userId", "gender", "level", "gear" };
            string[] values = { user.Id.ToString(), munchkin.Gender.ToString(), munchkin.Level.ToString(), munchkin.Gear.ToString() };

            crud.Write(table, arguments, values);
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

        public void RemoveMunchkin(User user, Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }
    }
}
