using Interfaces.Munchkins;
using DAL.Repositories;
using DAL.Contexts.Munchkins;

namespace Factories
{
    public static class MunchkinFactory
    {
        public static IMunchkinRepository GetMunchkinRepository()
        {
            return new MunchkinRepository();
        }

        public static IMunchkinRepository GetMunchkinRepositoryTest()
        {
            return new MunchkinRepository(new MunchkinContextMemory());
        }
    }
}
