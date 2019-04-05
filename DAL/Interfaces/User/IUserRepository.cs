using Models.Interfaces;
using System.Collections.Generic;

namespace DAL.Interfaces.User
{
    public interface IUserRepository
    {
        void Logout();

        void AddMunchkin(IMunchkin munchkin);
        void RemoveMunchkin(IMunchkin munchkin);
        IEnumerable<IMunchkin> GetAllMunchkins();
        IMunchkin GetMunchkinById(int id);
    }
}
