using System;
using System.Collections.Generic;
using Models.Enums;
using Newtonsoft.Json;

namespace Models
{
    public class Game
    {
        public int Id { get; set; }
        public GameStatus Status { get; set; }
        public DateTime DateTimePlayed { get; set; }
        public List<Munchkin> Munchkins { get; set; }
        public Munchkin Winner { get; set; }

        public Game()
        {
            Status = GameStatus.Setup;
            DateTimePlayed = DateTime.Now;
            Munchkins = new List<Munchkin>();
        }

        public Game(int id, GameStatus status, DateTime dateTime, Munchkin winner)
        {
            Id = id;
            Status = status;
            DateTimePlayed = dateTime;
            Winner = winner;
        }

        public Game(int id, GameStatus status, DateTime datePlayed, List<Munchkin> munchkins)
        {
            Munchkins = new List<Munchkin>();

            Id = id;
            Status = status;
            DateTimePlayed = datePlayed;
            Munchkins = munchkins;
        }

        [JsonConstructor]
        public Game(int id, GameStatus status, DateTime datePlayed, List<Munchkin> munchkins, Munchkin winner)
        {
            Munchkins = new List<Munchkin>();

            Id = id;
            Status = status;
            DateTimePlayed = datePlayed;
            Munchkins = munchkins;
            Winner = winner;
        }
    }
}
