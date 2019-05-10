using Models;
using System.Collections.Generic;

namespace Interfaces.Users
{
    public interface IUserCollectionRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}
