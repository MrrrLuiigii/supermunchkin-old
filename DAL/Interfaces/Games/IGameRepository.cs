using Models;
using Models.Enums;

namespace DAL.Interfaces.Games
{
    public interface IGameRepository
    {
        void AdjustGameStatus(GameStatus status);
        void SetWinner(Munchkin munchkin);

        void AddMunchkin(Munchkin munchkin);
        void RemoveMunchkin(Munchkin munchkin);
    }
}
