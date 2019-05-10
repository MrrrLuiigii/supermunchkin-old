using Models;
using System.Collections.Generic;

namespace Interfaces.Users
{
    public interface IUserCollectionRepository
    {
        void AddUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
    }
}
