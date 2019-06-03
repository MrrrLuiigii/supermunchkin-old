using Factories;
using Interfaces.Battles;
using Models;
using Models.Enums;

namespace Logic.Battles
{
    public class BattleLogic
    {
        private IBattleRepository battleRepository;

        public BattleLogic(IBattleRepository repository = null)
        {
            battleRepository = repository ?? BattleFactory.GetBattleRepository();
        }

        public void AddMunchkin(Battle battle, Munchkin munchkin) => battleRepository.AddMunchkin(battle, munchkin);
        public void RemoveMunchkin(Battle battle, Munchkin munchkin) => battleRepository.RemoveMunchkin(battle, munchkin);
        public void AddMonster(Battle battle, Monster monster) => battleRepository.AddMonster(battle, monster);
        public void RemoveMonster(Battle battle, Monster monster) => battleRepository.RemoveMonster(battle, monster);
        public void AdjustBattleStatus(Battle battle)
        {
            int totalMonsterPower = 0;
            int totalMunchkinPower = 0;

            foreach (Monster monster in battle.Monsters)
            {
                totalMonsterPower += monster.Level;
                totalMonsterPower += monster.Modifier;
            }

            foreach (Munchkin munchkin in battle.Munchkins)
            {
                totalMunchkinPower += munchkin.Level;
                totalMunchkinPower += munchkin.Gear;
                totalMunchkinPower += munchkin.Modifier;
            }

            if (totalMonsterPower >= totalMunchkinPower)
            {
                battle.Status = BattleStatus.Lost;
            }
            else
            {
                battle.Status = BattleStatus.Won;
            }

            battleRepository.AdjustBattleStatus(battle);
        }
            
    }
}
