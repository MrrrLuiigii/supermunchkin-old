﻿using Models;
using Logic.Games;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;
using Models.Enums;
using Logic.Users;

namespace SuperMunchkin.Controllers
{
    public class GameController : Controller
    {
        private UserLogic userLogic = new UserLogic();
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

        public IActionResult GameOverview(int id)
        {
            Game game = gameCollectionLogic.GetGameById(id);

            if (game.Status == GameStatus.Setup)
            {
                return GameSetup(game);
            }

            return View(game);
        }

        public IActionResult History()
        {
            return View();
        }

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