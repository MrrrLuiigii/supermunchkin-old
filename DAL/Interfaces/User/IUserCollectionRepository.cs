using System.Collections.Generic;

namespace DAL.Interfaces.User
{
    public interface IUserCollectionRepository
    {
        void AddUser(User user);
        User Login(string username, string password);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}
