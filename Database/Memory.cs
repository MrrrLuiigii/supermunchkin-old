using Models;
using Models.Enums;
using System;
using System.Collections.Generic;

namespace Database
{
    public class Memory
    {
        public static List<User> Users;
        public static List<Munchkin> Munchkins;
        public static List<Game> Games;

        public Memory()
        {
            Munchkins = new List<Munchkin>();

            Munchkins.Add(new Munchkin(1, MunchkinGender.Female, 8, 12));
            Munchkins.Add(new Munchkin(2, MunchkinGender.Male, 9, 15));
            Munchkins.Add(new Munchkin(3, MunchkinGender.Male, 5, 20));
            Munchkins.Add(new Munchkin(4, MunchkinGender.Female, 7, 11));
            Munchkins.Add(new Munchkin(5, MunchkinGender.Male, 10, 17));
            Munchkins.Add(new Munchkin(6, MunchkinGender.Male, 6, 10));

            Users = new List<User>();

            Users.Add(new User(1, "Nicky", "admin", "nicky@gmail.com"));
            Users.Add(new User(2, "Mario", "user", "mario@gmail.com"));
            Users.Add(new User(3, "Sjoerd", "user", "sjoerd@gmail.com"));
            Users.Add(new User(4, "Nick", "user", "nick@gmail.com"));
            Users.Add(new User(5, "Tom", "user", "tom@gmail.com"));
            Users.Add(new User(6, "Beau", "user", "beau@gmail.com"));

            Games = new List<Game>();

            Games.Add(new Game(1, GameStatus.Finished, DateTime.Now, Munchkins, Munchkins[4]));
            Games.Add(new Game(2, GameStatus.Finished, DateTime.Now, Munchkins, Munchkins[2]));
            Games.Add(new Game(3, GameStatus.Finished, DateTime.Now, Munchkins, Munchkins[5]));
            Games.Add(new Game(4, GameStatus.Finished, DateTime.Now, Munchkins, Munchkins[0]));
            Games.Add(new Game(5, GameStatus.Finished, DateTime.Now, Munchkins, Munchkins[1]));
            Games.Add(new Game(6, GameStatus.Playing, DateTime.Now, Munchkins));
        }

        public User GetUserById(int id)
        {
            User user = null;

            foreach (User u in Users)
            {
                if(u.Id == id)
                {
                    user = u;
                }
            }

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Users;
        }

        public Game GetGameById(int id)
        {
            Game game = null;

            foreach (Game g in Games)
            {
                if(g.Id == id)
                {
                    game = g;
                }
            }

            return game;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return Games;
        }
    }
}
