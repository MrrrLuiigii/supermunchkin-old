using Factories;
using Interfaces.Battles;

namespace Logic.Battles
{
    public class BattleCollectionLogic
    {
        private IBattleCollectionRepository battleCollectionRepository;

        public BattleCollectionLogic(IBattleCollectionRepository bcRepository = null)
        {
            battleCollectionRepository = bcRepository ?? BattleFactory.GetBattleCollectionRepository();
        }
    }
}
