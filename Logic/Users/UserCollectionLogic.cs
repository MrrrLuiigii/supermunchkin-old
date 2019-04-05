using DAL.Interfaces.Users;
using DAL.Repositories;
using Models;

namespace Logic.Users
{
    public class UserCollectionLogic
    {
        IUserCollectionRepository userRepo = new UserRepository();

        public void AddUser(User user)
        {
            userRepo.AddUser(user);
        }
    }
}
