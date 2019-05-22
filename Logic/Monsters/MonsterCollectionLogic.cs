using Factories;
using Interfaces.Monsters;
using Models;
using System.Collections.Generic;

namespace Logic.Monsters
{
    public class MonsterCollectionLogic
    {
        private IMonsterCollectionRepository mcRepository;

        public MonsterCollectionLogic(IMonsterCollectionRepository repository = null)
        {
            mcRepository = repository ?? MonsterFactory.GetMonsterCollectionRepository();
        }

        public void CreateMonster(Monster monster) => mcRepository.CreateMonster(monster);

        public void RemoveMonster(Monster monster) => mcRepository.RemoveMonster(monster);

        public Monster GetMonsterById(int id) => mcRepository.GetMonsterById(id);

        public List<Monster> GetAllMonstersByBattle(Battle battle) => mcRepository.GetAllMonstersByBattle(battle);
    }
}
