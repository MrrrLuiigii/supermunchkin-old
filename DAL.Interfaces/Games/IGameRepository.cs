using Models;
using Models.Enums;
using System.Collections.Generic;

namespace Interfaces.Games
{
    public interface IGameRepository
    {
        void AdjustGameStatus(Game game, GameStatus status);
        void SetWinner(Game game, Munchkin munchkin);
        void AddMunchkin(Game game, Munchkin munchkin);
        void RemoveMunchkin(Game game, Munchkin munchkin);

        void AddBattle(Game game, Battle battle);
        void RemoveBattle(Game game, Battle battle);
        List<Battle> GetAllBattlesByGame(Game game);
        Battle GetBattleById(int id);
        List<Battle> GetAllBattlesByMunchkin(Munchkin munchkin);
    }
}
