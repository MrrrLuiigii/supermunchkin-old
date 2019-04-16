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

            List<Game> userGames = gameCollectionLogic.GetAllGamesByUser(user);
            ViewBag.UserGames = userGames;
            
            return View();
        }

        [Authorize]
        public IActionResult CreateNewGame()
        {
            Game game = new Game();
            game = gameCollectionLogic.AddGame(game);            
            return RedirectToAction("GameSetup", "Game", new { game.Id });
        }

        [Authorize]
        public IActionResult GameSetup(int id)
        {
            Game game = gameCollectionLogic.GetGameById(id);
            return View(game);
        }

        [Authorize]
        public IActionResult GameOverview(int id)
        {
            Game game = gameCollectionLogic.GetGameById(id);

            if (game.Status == GameStatus.Setup)
            {
                return RedirectToAction("GameSetup", "Game", new { id });
            }

            return View(game);
        }

        [Authorize]
        public IActionResult History()
        {
            return View();
        }

        [Authorize]
        public IActionResult SetWinner(int gameId, int munchkinId)
        {
            Game game = gameCollectionLogic.GetGameById(gameId);
            Munchkin munchkin = userLogic.GetMunchkinById(munchkinId);
            gameLogic.SetWinner(game, munchkin);
            gameLogic.AdjustGameStatus(game, GameStatus.Finished);
            return RedirectToAction("GameLobby", "Game");
        }
    }
}