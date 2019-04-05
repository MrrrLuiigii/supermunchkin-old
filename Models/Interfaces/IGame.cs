using Models.Enums;
using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface IGame
    {
        int Id { get; set; }
        GameStatus Status { get; set; }
        DateTime DatePlayed { get; set; }
        IEnumerable<IMunchkin> Munchkins { get; set; }
        IMunchkin Winner { get; set; }
    }
}
