using Interfaces.Users;
using DAL.Repositories;
using DAL.Contexts.Users;

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

        public static IUserRepository GetUserRepositoryTest()
        {
            return new UserRepository(new UserContextMemory());
        }

        public static IUserRepository GetUserCollectionRepositoryTest()
        {
            return new UserRepository(new UserContextMemory());
        }
    }
}
