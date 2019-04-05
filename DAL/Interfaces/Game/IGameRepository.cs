using Models.Enums;

namespace DAL.Interfaces
{
    public interface IGameRepository
    {
        void AdjustGameStatus(GameStatus status);
        void SetWinner(Munchkin munchkin);

        void AddMunchkin(Munchkin munchkin);
        void RemoveMunchkin(Munchkin munchkin);
    }
}
