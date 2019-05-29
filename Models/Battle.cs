using System;
using System.Collections.Generic;
using Models.Enums;

namespace Models
{
    public class Battle
    {
        public int Id { get; set; }
        public BattleStatus Status { get; set; }
        public DateTime DateTimeBattled { get; set; }
        public List<Munchkin> Munchkins { get; set; }
        public List<Monster> Monsters { get; set; }

        public Battle()
        {
            Status = BattleStatus.Ongoing;
            DateTimeBattled = DateTime.Now;
            Munchkins = new List<Munchkin>();
            Monsters = new List<Monster>();
        }

        public Battle(int id, BattleStatus status, DateTime dateTimeBattled, List<Munchkin> munchkins, List<Monster> monsters)
        {
            Id = id;
            Status = status;
            DateTimeBattled = dateTimeBattled;
            Munchkins = munchkins;
            Monsters = monsters;
        }

        public Battle(int id, BattleStatus status, DateTime dateTimeBattled)
        {
            Id = id;
            Status = status;
            DateTimeBattled = dateTimeBattled;
            Munchkins = new List<Munchkin>();
            Monsters = new List<Monster>();
        }
    }
}
