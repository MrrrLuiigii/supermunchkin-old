using DAL.Contexts.Munchkins;
using DAL.Interfaces.Munchkins;
using Models;
using Models.Enums;

namespace DAL.Repositories
{
    public class MunchkinRepository : IMunchkinRepository
    {
        //private IMunchkinContext munchkinContext = new MunchkinContextMemory();
        private IMunchkinContext munchkinContext = new MunchkinContextSQL();

        public void AdjustMunchkin(Munchkin munchkin)
        {
            munchkinContext.AdjustMunchkin(munchkin);
        }
    }
}
