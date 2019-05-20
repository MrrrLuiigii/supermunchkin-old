using Models;
using Logic.Games;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Models.Enums;
using Logic.Users;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System;

namespace SuperMunchkin.Controllers
{
    public class GameController : Controller
    {
        private UserLogic userLogic = new UserLogic();
        private GameLogic gameLogic = new GameLogic();
        private GameCollectionLogic gameCollectionLogic = new GameCollectionLogic();

        [Authorize]
        public IActionResult GameLobby()
        {
            User user = JsonConvert.DeserializeObject<User>(((ClaimsIdentity)User.Identity).Claims.First().Value);
            ViewBag.LoggedInUser = user;

            List<Game> userGames = gameCollectionLogic.GetAllGamesByUser(user).Where(g => g.Status == GameStatus.Playing || g.Status == GameStatus.Setup).ToList();
            ViewBag.UserGames = userGames;
            
            return View();
        }

        [Authorize]
        public IActionResult CreateNewGame()
        {
            User user = JsonConvert.DeserializeObject<User>(((ClaimsIdentity)User.Identity).Claims.First().Value);

            Game game = new Game();
            game = gameCollectionLogic.AddGame(game, user);

            if (game == null)
            {
                return RedirectToAction("GameLobby", "Game");
            }

            return RedirectToAction("GameSetup", "Game", new { game.Id });
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            Game game = gameCollectionLogic.GetGameById(id);
            gameCollectionLogic.RemoveGame(game);
            return RedirectToAction("GameLobby", "Game");
        }

        [Authorize]
        public IActionResult GameSetup(int id)
        {
            Game game = gameCollectionLogic.GetGameById(id);
            return View(game);
        }

        [Authorize]
        public IActionResult AdjustGameStatus(int id)
        {
            Game game = gameCollectionLogic.GetGameById(id);
            gameLogic.AdjustGameStatus(game, GameStatus.Playing);
            return RedirectToAction("GameOverview", "Game", new { id });
        }

        [Authorize]
        public IActionResult GameOverview(int id, int diceInt)
        {
            Game game = gameCollectionLogic.GetGameById(id);
            Response.Cookies.Append("GameId", game.Id.ToString());

            if (game.Status == GameStatus.Setup)
            {
                return RedirectToAction("GameSetup", "Game", new { id });
            }

            ViewBag.DiceInt = diceInt;
            return View(game);
        }

        [Authorize]
        public IActionResult RollDice(int id)
        {
            int diceInt = gameLogic.RollDice();
            return RedirectToAction("GameOverview", "Game", new { id, diceInt });
        }

        [Authorize]
        public IActionResult HistoryLobby()
        {
            User user = JsonConvert.DeserializeObject<User>(((ClaimsIdentity)User.Identity).Claims.First().Value);
            ViewBag.LoggedInUser = user;

            List<Game> userGames = gameCollectionLogic.GetAllGamesByUser(user).Where(g => g.Status == GameStatus.Finished).ToList();
            ViewBag.UserGames = userGames;

            return View();
        }

        [Authorize]
        public IActionResult HistoryOverview(int id)
        {
            Game game = gameCollectionLogic.GetGameById(id);
            Response.Cookies.Append("GameId", id.ToString());
            return View(game);
        }

        [Authorize]
        public IActionResult SetWinner(int id)
        {
            Game game = gameCollectionLogic.GetGameById(Convert.ToInt32(Request.Cookies["GameId"]));
            Munchkin munchkin = userLogic.GetMunchkinById(id);
            gameLogic.SetWinner(game, munchkin);
            gameLogic.AdjustGameStatus(game, GameStatus.Finished);
            return RedirectToAction("HistoryOverview", "Game", new { game.Id });
        }
    }
}