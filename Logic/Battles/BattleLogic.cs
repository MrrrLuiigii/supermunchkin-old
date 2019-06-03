using Factories;
using Interfaces.Battles;
using Models;

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
    }
}
