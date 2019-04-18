using Models;
using System.Collections.Generic;

namespace DAL.Interfaces.Users
{
    public interface IUserRepository
    {
        void AddMunchkin(User user, Munchkin munchkin);
        void RemoveMunchkin(Munchkin munchkin);
        IEnumerable<Munchkin> GetAllMunchkins();
    }
}
