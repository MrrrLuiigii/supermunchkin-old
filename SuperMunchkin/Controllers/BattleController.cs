using Logic.Games;
using Logic.Users;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;

namespace SuperMunchkin.Controllers
{
    public class BattleController : Controller
    {
        private UserLogic userLogic = new UserLogic();
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

        public IActionResult AddMonster()
        {
            return RedirectToAction("Index");
        }
    }
}