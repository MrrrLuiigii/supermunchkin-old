using Logic.Games;
using Logic.Munchkins;
using Logic.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using System;

namespace SuperMunchkin.Controllers
{
    public class BattleController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        private MunchkinLogic munchkinLogic = new MunchkinLogic();
        private GameLogic gameLogic = new GameLogic();
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();

        public IActionResult Index(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);

            int gameId = Convert.ToInt32(Request.Cookies["GameId"]);
            Game game = gameCollectionLogic.GetGameById(gameId);

            Battle battle = gameLogic.GetActiveBattleByMunchkinAndGame(game, munchkin);

            ViewBag.Munchkin = munchkin;

            return View(battle);
        }

        public IActionResult AddMunchkin()
        {
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RollDice(int id)
        {
            int diceInt = gameLogic.RollDice();
            return RedirectToAction("Index", "Game", new { id, diceInt });
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
    }
}