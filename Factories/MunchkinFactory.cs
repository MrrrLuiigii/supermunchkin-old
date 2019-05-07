using Interfaces.Munchkins;
using DAL.Repositories;

namespace Factories
{
    public static class MunchkinFactory
    {
        public static IMunchkinRepository GetMunchkinRepository()
        {
            return new MunchkinRepository();
        }

        public static IMunchkinRepository GetMunchkinRepositoryTest(IMunchkinContext context)
        {
            return new MunchkinRepository(context);
        }
    }
}
