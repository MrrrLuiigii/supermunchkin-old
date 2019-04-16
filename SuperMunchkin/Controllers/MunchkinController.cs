using Logic.Games;
using Logic.Munchkins;
using Logic.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using Newtonsoft.Json;
using SuperMunchkin.ViewModels;

namespace SuperMunchkin.Controllers
{
    public class MunchkinController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        private MunchkinLogic munchkinLogic = new MunchkinLogic();
        private GameLogic gameLogic = new GameLogic();
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Add(int id)
        {
            Game game = gameCollectionLogic.GetGameById(id);
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(MunchkinViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("GameSetup", "Game");
            }
            
            ViewBag.ErrorMessage = "Make sure all fields are filled in correctly.";
            return View(mvm);
        }

        [Authorize]
        public IActionResult Remove(int id, int gameId)
        {
            Game game = gameCollectionLogic.GetGameById(gameId);

            Munchkin munchkin = userLogic.GetMunchkinById(id);
            return RedirectToAction("GameSetup", "Game", new { game.Id });
        }

        [Authorize]
        public IActionResult MunchkinEdit(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            return View(munchkin);
        }

        [Authorize]
        public IActionResult AdjustGender(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustGender(munchkin);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }

        [Authorize]
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

        [Authorize]
        public IActionResult AdjustGear(int id, AdjustMunchkinStats direction)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustGear(munchkin, direction);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }
    }
}