using Models;
using Logic.Games;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Models.Enums;

namespace SuperMunchkin.Controllers
{
    public class GameController : Controller
    {
        private GameLogic gameLogic = new GameLogic();
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();

        public IActionResult GameLobby()
        {
            User user = JsonConvert.DeserializeObject<User>(Request.Cookies["LoggedInUser"]);
            ViewBag.LoggedInUser = user;

            List<Game> userGames = gameCollectionLogic.GetAllGamesByUser(user);
            ViewBag.UserGames = userGames;
            
            return View();
        }

        public IActionResult GameSetup()
        {
            Game game = new Game();
            gameCollectionLogic.AddGame(game);

            ViewBag.ActiveGame = game;
            return View();
        }

        public IActionResult GameSetup(Game game)
        {
            return View(game);
        }

        public IActionResult GameOverview(Game game, GameStatus status, string munchkins)
        {
            game.Status = status;
            game.Munchkins = JsonConvert.DeserializeObject<List<Munchkin>>(munchkins);

            if (game.Status == GameStatus.Setup)
            {
                return GameSetup(game);
                //return RedirectToAction("GameSetup", "Game", new { game });
            }

            return View(game);
        }

        public IActionResult History()
        {
            return View();
        }
    }
}