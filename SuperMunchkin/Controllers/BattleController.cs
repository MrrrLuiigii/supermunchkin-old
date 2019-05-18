using Logic.Games;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;

namespace SuperMunchkin.Controllers
{
    public class BattleController : Controller
    {
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();

        public IActionResult Index()
        {
            int gameId = Convert.ToInt32(Request.Cookies["GameId"]);
            Game game = gameCollectionLogic.GetGameById(gameId);


            return View();
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