using DAL.Interfaces.Users;
using DAL.Repositories;

namespace Factories
{
    public static class UserFactory
    {
        public static IUserRepository GetUserRepository()
        {
            return new UserRepository();
        }

        public static IUserCollectionRepository GetUserCollectionRepository()
        {
            return new UserRepository();
        }
    }
}
