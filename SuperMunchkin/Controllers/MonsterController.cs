using Logic.Games;
using Logic.Monsters;
using Logic.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;

namespace SuperMunchkin.Controllers
{
    public class MonsterController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        private MonsterLogic monsterLogic = new MonsterLogic();
        private MonsterCollectionLogic monsterCollectionLogic = new MonsterCollectionLogic();
        private GameLogic gameLogic = new GameLogic();

        [Authorize]
        public IActionResult LevelUp(int id, int munchkinId, int battleId)
        {
            Monster monster = monsterCollectionLogic.GetMonsterById(id);
            Battle battle = gameLogic.GetBattleById(battleId);
            monsterLogic.AdjustLevel(monster, AdjustStats.Up, battle);
            id = munchkinId;
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult LevelDown(int id, int munchkinId, int battleId)
        {
            Monster munchkin = monsterCollectionLogic.GetMonsterById(id);
            Battle battle = gameLogic.GetBattleById(battleId);
            monsterLogic.AdjustLevel(munchkin, AdjustStats.Down, battle);
            id = munchkinId;
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult ModifierUp(int id, int battleId, int munchkinId)
        {
            Battle battle = gameLogic.GetBattleById(battleId);
            Monster munchkin = monsterCollectionLogic.GetMonsterById(id);
            monsterLogic.AdjustModifier(munchkin, AdjustStats.Up, battle);
            id = munchkinId;
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult ModifierDown(int id, int battleId, int munchkinId)
        {
            Battle battle = gameLogic.GetBattleById(battleId);
            Monster munchkin = monsterCollectionLogic.GetMonsterById(id);
            monsterLogic.AdjustModifier(munchkin, AdjustStats.Down, battle);
            id = munchkinId;
            return RedirectToAction("Index", "Battle", new { id });
        }
    }
}