using System.Collections.Generic;
using DAL.Interfaces.User;
using Models.Interfaces;

namespace DAL.Contexts.User
{
    public class UserContextSQL : IUserContext
    {
        public void AddMunchkin(IMunchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        public void AddUser(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IMunchkin> GetAllMunchkins()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public IMunchkin GetMunchkinById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IUser GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IUser Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMunchkin(IMunchkin munchkin)
        {
            throw new System.NotImplementedException();
        }
    }
}
