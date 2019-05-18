using Factories;
using Interfaces.Battles;

namespace Logic.Battles
{
    public class BattleLogic
    {
        private IBattleRepository battleRepository;

        public BattleLogic(IBattleRepository repository = null)
        {
            battleRepository = repository ?? BattleFactory.GetBattleRepository();
        }
    }
}
