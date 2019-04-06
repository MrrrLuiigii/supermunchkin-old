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

        public Game()
        {
            DatePlayed = DateTime.Now;
        }

        public Game(int id, GameStatus status, DateTime datePlayed, IEnumerable<Munchkin> munchkins)
        {
            Id = id;
            Status = status;
            DatePlayed = datePlayed;
            Munchkins = munchkins;
        }

        public Game(int id, GameStatus status, DateTime datePlayed, IEnumerable<Munchkin> munchkins, Munchkin winner)
        {
            Id = id;
            Status = status;
            DatePlayed = datePlayed;
            Munchkins = munchkins;
            Winner = winner;
        }
    }
}
