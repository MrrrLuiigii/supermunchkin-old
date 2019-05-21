using Factories;
using Interfaces.Monsters;

namespace Logic.Monsters
{
    public class MonsterLogic
    {
        private IMonsterRepository monsterRepository;

        public MonsterLogic(IMonsterRepository repository = null)
        {
            monsterRepository = repository ?? MonsterFactory.GetMonsterRepository();
        }
    }
}
