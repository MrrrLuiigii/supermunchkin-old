using Logic.Games;
using Logic.Munchkins;
using Logic.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;
using SuperMunchkin.ViewModels;
using System;

namespace SuperMunchkin.Controllers
{
    public class MunchkinController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        private UserCollectionLogic userCollectionLogic = new UserCollectionLogic();
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
            ViewBag.Game = game;
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(MunchkinViewModel mvm, int id)
        {
            Game game = gameCollectionLogic.GetGameById(id);
            ViewBag.Game = game;

            if (ModelState.IsValid)
            {
                User user = userCollectionLogic.Login(mvm.Username, mvm.Password);

                if (user != null)
                {
                    Munchkin munchkin = new Munchkin(user.Username, mvm.Gender);
                    munchkin = userLogic.CreateMunchkin(user, munchkin);
                    gameLogic.AddMunchkin(game, munchkin);
                    userLogic.AddGame(user, game);
                    return RedirectToAction("GameSetup", "Game", new { id });
                }
            }

            ViewBag.ErrorMessage = "Make sure all fields are filled in correctly.";
            return View(mvm);
        }

        [Authorize]
        public IActionResult Remove(int id, int gameId)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            userLogic.RemoveMunchkin(munchkin);
            return RedirectToAction("GameSetup", "Game", new { gameId });
        }

        [Authorize]
        public IActionResult MunchkinEdit(int id, int diceInt)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            ViewBag.DiceInt = diceInt;
            ViewBag.Winner = null;
            ViewBag.GameId = Convert.ToInt32(Request.Cookies["GameId"]);

            if (munchkin.Level == 10)
            {
                ViewBag.Winner = munchkin;
            }

            return View(munchkin);
        }

        [Authorize]
        public IActionResult RollDice(int id)
        {
            int diceInt = gameLogic.RollDice();
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id, diceInt });
        }

        [Authorize]
        public IActionResult AdjustGender(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustGender(munchkin);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }

        [Authorize]
        public IActionResult LevelUp(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustLevel(munchkin, AdjustMunchkinStats.Up);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }

        [Authorize]
        public IActionResult LevelDown(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustLevel(munchkin, AdjustMunchkinStats.Down);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }

        [Authorize]
        public IActionResult GearUp(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustGear(munchkin, AdjustMunchkinStats.Up);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }

        [Authorize]
        public IActionResult GearDown(int id)
        {
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            munchkinLogic.AdjustGear(munchkin, AdjustMunchkinStats.Down);
            return RedirectToAction("MunchkinEdit", "Munchkin", new { id });
        }
    }
}