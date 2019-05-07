using Interfaces.Users;
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

        public static IUserRepository GetUserRepositoryTest(IUserContext context)
        {
            return new UserRepository(context);
        }

        public static IUserRepository GetUserCollectionRepositoryTest(IUserContext context)
        {
            return new UserRepository(context);
        }
    }
}
