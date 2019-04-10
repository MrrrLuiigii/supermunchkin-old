using System;
using System.Collections.Generic;
using Models.Enums;

namespace Models
{
    public class Game
    {
        public int Id { get; set; }
        public GameStatus Status { get; set; }
        public DateTime DatePlayed { get; }
        public List<Munchkin> Munchkins { get; }
        public Munchkin Winner { get; set; }

        public Game()
        {
            Status = GameStatus.Setup;
            DatePlayed = DateTime.Now;
            Munchkins = new List<Munchkin>();
        }

        public Game(int id, GameStatus status, DateTime datePlayed, List<Munchkin> munchkins)
        {
            Munchkins = new List<Munchkin>();

            Id = id;
            Status = status;
            DatePlayed = datePlayed;
            Munchkins = munchkins;
        }

        public Game(int id, GameStatus status, DateTime datePlayed, List<Munchkin> munchkins, Munchkin winner)
        {
            Munchkins = new List<Munchkin>();

            Id = id;
            Status = status;
            DatePlayed = datePlayed;
            Munchkins = munchkins;
            Winner = winner;
        }
    }
}
