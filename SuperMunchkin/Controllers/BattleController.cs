using Logic.Battles;
using Logic.Games;
using Logic.Monsters;
using Logic.Munchkins;
using Logic.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using System;

namespace SuperMunchkin.Controllers
{
    [Authorize]
    public class BattleController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        private MunchkinLogic munchkinLogic = new MunchkinLogic();
        private BattleLogic battleLogic = new BattleLogic();
        private GameLogic gameLogic = new GameLogic();
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();
        private MonsterCollectionLogic monsterCollectionLogic = new MonsterCollectionLogic();

        [Authorize]
        public IActionResult Index(int id, int diceInt)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);

            int gameId = Convert.ToInt32(Request.Cookies["GameId"]);
            Game game = gameCollectionLogic.GetGameById(gameId);

            Battle battle = gameLogic.GetActiveBattleByMunchkinAndGame(game, munchkin);

            ViewBag.Munchkin = munchkin;
            ViewBag.DiceInt = diceInt;

            return View(battle);
        }

        [Authorize]
        public IActionResult AddMunchkin(int id, int munchkinId)
        {
            Game game = gameCollectionLogic.GetGameById(Convert.ToInt32(Request.Cookies["GameId"]));
            ViewBag.Munchkins = game.Munchkins.FindAll(m => m.Id != munchkinId);
            ViewBag.BattleId = id;
            ViewBag.MunchkinId = munchkinId;
            return View();
        }

        [Authorize]        
        public IActionResult AddMunchkinToBattle(int id, int battle, int munchkin)
        {
            Battle b = gameLogic.GetBattleById(battle);
            Munchkin m = userLogic.GetMunchkinById(id);
            battleLogic.AddMunchkin(b, m);
            id = munchkin;
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult RemoveMunchkin(int id, int munchkinRemoveId, int munchkinId)
        {
            Battle battle = gameLogic.GetBattleById(id);
            Munchkin munchkinRemove = userLogic.GetMunchkinById(munchkinRemoveId);
            battleLogic.RemoveMunchkin(battle, munchkinRemove);
            id = munchkinId;
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult AddMonster(int id, int munchkinId)
        {
            Battle battle = gameLogic.GetBattleById(id);
            Monster monster = new Monster("Monster 2");
            monster.Id = monsterCollectionLogic.CreateMonster(monster);
            battleLogic.AddMonster(battle, monster);
            id = munchkinId;
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult RemoveMonster(int id, int monsterId, int munchkinId)
        {
            Battle battle = gameLogic.GetBattleById(id);
            Monster monster = monsterCollectionLogic.GetMonsterById(monsterId);
            battleLogic.RemoveMonster(battle, monster);
            id = munchkinId;
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult RollDice(int id)
        {
            int diceInt = gameLogic.RollDice();
            return RedirectToAction("Index", "Battle", new { id, diceInt });
        }

        [Authorize]
        public IActionResult LevelUp(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustLevel(munchkin, AdjustStats.Up);
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult LevelDown(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustLevel(munchkin, AdjustStats.Down);
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult GearUp(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustGear(munchkin, AdjustStats.Up);
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult GearDown(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustGear(munchkin, AdjustStats.Down);
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult ModifierUp(int id, int battleId)
        {
            Battle battle = gameLogic.GetBattleById(battleId);
            Munchkin munchkin = userLogic.GetMunchkinById(id, battleId);
            munchkinLogic.AdjustModifier(munchkin, AdjustStats.Up, battle);
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult ModifierDown(int id, int battleId)
        {
            Battle battle = gameLogic.GetBattleById(battleId);
            Munchkin munchkin = userLogic.GetMunchkinById(id, battleId);
            munchkinLogic.AdjustModifier(munchkin, AdjustStats.Down, battle);
            return RedirectToAction("Index", "Battle", new { id });
        }

        [Authorize]
        public IActionResult Finish(int id, int battleId)
        {
            Battle battle = gameLogic.GetBattleById(battleId);
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            battleLogic.AdjustBattleStatus(battle);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }
    }
}