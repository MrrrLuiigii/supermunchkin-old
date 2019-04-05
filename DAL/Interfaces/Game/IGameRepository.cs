using Models.Enums;
using Models.Interfaces;

namespace DAL.Interfaces
{
    public interface IGameRepository
    {
        void AdjustGameStatus(GameStatus status);
        int RollDice();
        void SetWinner(IMunchkin munchkin);

        void AddMunchkin(IMunchkin munchkin);
        void RemoveMunchkin(IMunchkin munchkin);
    }
}
