using System.Collections.Generic;

namespace DAL.Interfaces.User
{
    public interface IUserRepository
    {
        void Logout();

        void AddMunchkin(Munchkin munchkin);
        void RemoveMunchkin(Munchkin munchkin);
        IEnumerable<Munchkin> GetAllMunchkins();
        Munchkin GetMunchkinById(int id);
    }
}
