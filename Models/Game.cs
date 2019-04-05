using Models.Enums;
using System;

namespace Models
{
    public class Game
    {
        public int Id { get; set; }
        public GameStatus Status { get; set; }
        public DateTime DatePlayed { get; set; }
        public Munchkin Winner { get; set; }
    }
}
