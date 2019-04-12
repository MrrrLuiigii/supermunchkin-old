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

        public IActionResult Game()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}