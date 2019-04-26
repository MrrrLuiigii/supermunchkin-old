using Models;
using Models.Enums;

namespace Interfaces.Games
{
    public interface IGameRepository
    {
        void AdjustGameStatus(Game game, GameStatus status);
        void SetWinner(Game game, Munchkin munchkin);

        void AddMunchkin(Game game, Munchkin munchkin);
        void RemoveMunchkin(Game game, Munchkin munchkin);
    }
}
