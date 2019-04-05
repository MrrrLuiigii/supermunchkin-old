using System;
using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public DateTime DatePlayed { get; set; }
        public IEnumerable<IMunchkin> Munchkins { get; set; }
        public IMunchkin Winner { get; set; }
    }
}
