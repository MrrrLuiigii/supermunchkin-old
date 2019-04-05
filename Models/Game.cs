using System;
using System.Collections.Generic;
using Models.Enums;

namespace Models
{
    public class Game
    {
        public int Id { get; set; }
        public GameStatus Status { get; set; }
        public DateTime DatePlayed { get; set; }
        public IEnumerable<Munchkin> Munchkins { get; set; }
        public Munchkin Winner { get; set; }
    }
}
