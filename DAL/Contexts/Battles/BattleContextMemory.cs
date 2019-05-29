using Interfaces.Battles;
using Models;

namespace DAL.Contexts.Battles
{
    public class BattleContextMemory : IBattleContext
    {
        public void AddMonster(Battle battle, Monster monster)
        {
            throw new System.NotImplementedException();
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
