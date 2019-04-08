using Logic.Games;
using Logic.Munchkins;
using Logic.Users;
using Microsoft.AspNetCore.Mvc;
using Models;
using SuperMunchkin.ViewModels;

namespace SuperMunchkin.Controllers
{
    public class MunchkinController : Controller
    {
        private MunchkinLogic munchkinLogic = new MunchkinLogic();

        private GameLogic gameLogic = new GameLogic();
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(Game game)
        {
            ViewBag.ActiveGame = game;
            return View();
        }

        [HttpPost]
        public IActionResult Add(MunchkinViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Game");
            }

            return View(mvm);
        }

        public IActionResult Remove(Munchkin munchkin)
        {
            return RedirectToAction("Index", "Game");
        }
    }
}