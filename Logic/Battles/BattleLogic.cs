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
    }
}
