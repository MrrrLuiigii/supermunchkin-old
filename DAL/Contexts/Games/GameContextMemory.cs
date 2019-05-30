using System.Collections.Generic;
using Interfaces.Games;
using Databases;
using Models;
using Models.Enums;

namespace DAL.Contexts.Games
{
    public class GameContextMemory : IGameContext
    {
        private Memory memory = new Memory();

        public Game AddGame(Game game, User user)
        {
            return null;
            //Add game
        }

        public void RemoveGame(Game game)
        {
            //Remove game
        }

        public void AddMunchkin(Game game, Munchkin munchkin)
        {
            //Add munchkin
        }

        public void AdjustGameStatus(Game game, GameStatus status)
        {
            //Adjust gamestatus
        }

        public List<Game> GetAllGames()
        {
            return memory.GetAllGames();
        }

        public List<Game> GetAllGamesByUser(User user)
        {
            return memory.GetGamesByUser(user);
        }

        public Game GetGameById(int id)
        {
            return memory.GetGameById(id);
        }

        public void RemoveMunchkin(Game game, Munchkin munchkin)
        {
            //Remove munchkin
        }

        public void SetWinner(Game game, Munchkin munchkin)
        {
            //Set winner
        }

        public void AddBattle(Game game, Battle battle)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveBattle(Game game, Battle battle)
        {
            throw new System.NotImplementedException();
        }

        public List<Battle> GetAllBattlesByGame(Game game)
        {
            throw new System.NotImplementedException();
        }

        public Battle GetBattleById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Battle> GetAllBattlesByMunchkin(Munchkin munchkin)
        {
            throw new System.NotImplementedException();
        }

        Battle IGameRepository.AddBattle(Game game, Battle battle)
        {
            throw new System.NotImplementedException();
        }
    }
}