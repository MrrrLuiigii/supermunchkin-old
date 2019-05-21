using DAL.Contexts.Munchkins;
using Interfaces.Munchkins;
using Models;

namespace DAL.Repositories
{
    public class MunchkinRepository : IMunchkinRepository
    {
        private IMunchkinContext munchkinContext;

        public MunchkinRepository(IMunchkinContext context = null)
        {
            munchkinContext = context ?? new MunchkinContextSQL();
        }

        public void AdjustMunchkin(Munchkin munchkin) => munchkinContext.AdjustMunchkin(munchkin);
    }
}
