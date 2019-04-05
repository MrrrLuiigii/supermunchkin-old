using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IGame
    {
        int Id { get; set; }
        DateTime DatePlayed { get; set; }
        IEnumerable<IMunchkin> Munchkins { get; set; }
        IMunchkin Winner { get; set; }
    }
}
