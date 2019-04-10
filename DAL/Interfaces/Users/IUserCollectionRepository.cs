using Models;
using System.Collections.Generic;

namespace DAL.Interfaces.Users
{
    public interface IUserCollectionRepository
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
    }
}
