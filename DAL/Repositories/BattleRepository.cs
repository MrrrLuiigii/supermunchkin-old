using DAL.Contexts.Battles;
using Interfaces.Battles;
using Models;

namespace DAL.Repositories
{
    public class BattleRepository : IBattleRepository
    {
        private IBattleContext battleContext;

        public BattleRepository(IBattleContext context = null)
        {
            battleContext = context ?? new BattleContextSQL();
        }

        public void AddMonster(Battle battle, Monster monster) => battleContext.AddMonster(battle, monster);

        public void AddMunchkin(Battle battle, Munchkin munchkin) => battleContext.AddMunchkin(battle, munchkin);

        public void AdjustBattleStatus(Battle battle) => battleContext.AdjustBattleStatus(battle);

        public void RemoveMonster(Battle battle, Monster monster) => battleContext.RemoveMonster(battle, monster);

        public void RemoveMunchkin(Battle battle, Munchkin munchkin) => battleContext.RemoveMunchkin(battle, munchkin);
    }
}
