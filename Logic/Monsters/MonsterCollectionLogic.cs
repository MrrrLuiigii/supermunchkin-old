using Factories;
using Interfaces.Monsters;

namespace Logic.Monsters
{
    public class MonsterCollectionLogic
    {
        private IMonsterCollectionRepository mcRepository;

        public MonsterCollectionLogic(IMonsterCollectionRepository repository = null)
        {
            mcRepository = repository ?? MonsterFactory.GetMonsterCollectionRepository();
        }
    }
}
