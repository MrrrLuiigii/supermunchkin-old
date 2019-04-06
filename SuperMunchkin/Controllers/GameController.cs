using Models;
using Logic.Games;
using Logic.Users;
using Microsoft.AspNetCore.Mvc;

namespace SuperMunchkin.Controllers
{
    public class GameController : Controller
    {
        private GameLogic gameLogic = new GameLogic();
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();
        private UserCollectionLogic userCollectionLogic = new UserCollectionLogic();

        public IActionResult Index(int userId)
        {
            User user = userCollectionLogic.GetUserById(userId);
            ViewBag.LoggedInUser = user;

            Game game = new Game();
            gameCollectionLogic.AddGame(game);

            ViewBag.ActiveGame = game;

            return View();
        }

        public IActionResult History()
        {
            return View();
        }
    }
}