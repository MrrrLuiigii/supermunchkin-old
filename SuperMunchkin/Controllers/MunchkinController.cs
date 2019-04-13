using Logic.Games;
using Logic.Munchkins;
using Logic.Users;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using SuperMunchkin.ViewModels;

namespace SuperMunchkin.Controllers
{
    public class MunchkinController : Controller
    {
        private UserLogic userLogic = new UserLogic();
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

        public IActionResult MunchkinEdit(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            return View(munchkin);
        }

        public IActionResult AdjustGender(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustGender(munchkin);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }

        public IActionResult AdjustLevel(int id, AdjustMunchkinStats direction)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            ViewBag.Winner = null;

            if (munchkinLogic.AdjustLevel(munchkin, direction))
            {
                ViewBag.Winner = munchkin;
            }

            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }

        public IActionResult AdjustGear(int id, AdjustMunchkinStats direction)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustGear(munchkin, direction);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }
    }
}