using Databases;
using Interfaces.Battles;
using Models;

namespace DAL.Contexts.Battles
{
    public class BattleContextSQL : IBattleContext
    {
        private Database database = new Database();

        public void AddMonster(Battle battle, Monster monster)
        {
            string sql = 
                "insert into `monster-battle`(`BattleId`, `MonsterId`, `Modifier`)" +
                "values (@BattleId, @MonsterId, @Modifier)";
        }

        public void AddMunchkin(Battle battle, Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        public void AdjustBattleStatus(Battle battle)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMonster(Battle battle, Monster monster)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveMunchkin(Battle battle, Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }
    }
}
