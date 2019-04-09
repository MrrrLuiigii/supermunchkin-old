using Models;
using Logic.Games;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace SuperMunchkin.Controllers
{
    public class GameController : Controller
    {
        private GameLogic gameLogic = new GameLogic();
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();

        public IActionResult Index()
        {
            User user = JsonConvert.DeserializeObject<User>(Request.Cookies["LoggedInUser"]);
            ViewBag.LoggedInUser = user;

            Game game = new Game();
            
            game.Munchkins.Add(new Munchkin(1, "Nicky", Models.Enums.MunchkinGender.Male, 8, 15));

            gameCollectionLogic.AddGame(game);

            ViewBag.ActiveGame = game;
            return View();
        }

        public IActionResult Game(Game game)
        {
            ViewBag.ActiveGame = game;
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}