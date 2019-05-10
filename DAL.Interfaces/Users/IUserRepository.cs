using Models;
using System.Collections.Generic;

namespace Interfaces.Users
{
    public interface IUserRepository
    {
        Munchkin AddMunchkin(User user, Munchkin munchkin);
        void RemoveMunchkin(Munchkin munchkin);
        List<Munchkin> GetAllMunchkins();
        List<Munchkin> GetAllMunchkinsByUser(User user);
        Munchkin GetMunchkinById(int id);
    }
}
