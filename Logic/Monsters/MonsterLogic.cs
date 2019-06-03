using Factories;
using Interfaces.Monsters;
using Models;
using Models.Enums;

namespace Logic.Monsters
{
    public class MonsterLogic
    {
        private IMonsterRepository monsterRepository;

        public MonsterLogic(IMonsterRepository repository = null)
        {
            monsterRepository = repository ?? MonsterFactory.GetMonsterRepository();
        }

        public void AdjustLevel(Monster monster, AdjustStats direction, Battle battle)
        {
            if (direction == AdjustStats.Down)
            {
                if (monster.Level > 0)
                {
                    monster.Level -= 1;
                }
                else
                {
                    monster.Level = 0;
                }
            }
            else if (direction == AdjustStats.Up)
            {
                monster.Level += 1;
            }

            monsterRepository.AdjustMonster(monster, battle);
        }

        public void AdjustModifier(Monster monster, AdjustStats direction, Battle battle)
        {
            if (direction == AdjustStats.Down)
            {
                monster.Modifier -= 1;
            }
            else if (direction == AdjustStats.Up)
            {
                monster.Modifier += 1;
            }

            monsterRepository.AdjustMonster(monster, battle);
        }
    }
}
