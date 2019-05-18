using DAL.Contexts.Battles;
using Interfaces.Battles;

namespace DAL.Repositories
{
    public class BattleRepository : IBattleRepository, IBattleCollectionRepository
    {
        private IBattleContext battleContext;

        public BattleRepository(IBattleContext context = null)
        {
            battleContext = context ?? new BattleContextSQL();
        }
    }
}
