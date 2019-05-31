using Interfaces.Games;
using Factories;
using Models;
using Models.Enums;
using System;
using System.Collections.Generic;

namespace Logic.Games
{
    public class GameLogic
    {
        private IGameRepository gameRepository;

        public GameLogic(IGameRepository repository = null)
        {
            gameRepository = repository ?? GameFactory.GetGameRepository();
        }

        public void AddMunchkin(Game game, Munchkin munchkin) => gameRepository.AddMunchkin(game, munchkin);

        public void RemoveMunchkin(Game game, Munchkin munchkin) => gameRepository.RemoveMunchkin(game, munchkin);

        public void SetWinner(Game game, Munchkin munchkin) => gameRepository.SetWinner(game, munchkin);

        public void AdjustGameStatus(Game game, GameStatus status) => gameRepository.AdjustGameStatus(game, status);

        public int RollDice() => new Random().Next(1, 7);

        public Battle GetActiveBattleByMunchkinAndGame(Game game, Munchkin munchkin)
        {
            List<Battle> battles = gameRepository.GetAllBattlesByGame(game);

            foreach (Battle b in battles)
            {
                if (b.Status == BattleStatus.Ongoing)
                {
                    if (b.Munchkins.Find(m => m.Id == munchkin.Id) != null)
                    {
                        return b;
                    }
                }
            }

            return AddBattle(game, munchkin);
        }

        public Battle AddBattle(Game game, Munchkin munchkin)
        {
            Battle battle = new Battle();
            battle.Munchkins.Add(munchkin);
            battle = gameRepository.AddBattle(game, battle);

            return battle;
        }

        public Battle GetBattleById(int id) => gameRepository.GetBattleById(id);
    }
}
