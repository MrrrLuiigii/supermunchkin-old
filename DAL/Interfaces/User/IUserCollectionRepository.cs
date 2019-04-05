using Models.Interfaces;
using System.Collections.Generic;

namespace DAL.Interfaces.User
{
    public interface IUserCollectionRepository
    {
        void AddUser(IUser user);
        IUser Login(string username, string password);
        IEnumerable<IUser> GetAllUsers();
        IUser GetUserById(int id);
    }
}
