using Models;
using Models.Enums;
using System;
using System.Collections.Generic;

namespace Databases
{
    public class Memory
    {
        public static List<User> Users;
        public static List<Munchkin> Munchkins;
        public static List<Game> Games;

        public Memory()
        {
            List<Munchkin> FinishedMunchkinsOne = new List<Munchkin>();
            FinishedMunchkinsOne.Add(new Munchkin(1, "Nicky", MunchkinGender.Male, 8, 12));
            FinishedMunchkinsOne.Add(new Munchkin(3, "Mario", MunchkinGender.Male, 5, 20));
            FinishedMunchkinsOne.Add(new Munchkin(5, "Sjoerd", MunchkinGender.Male, 10, 17));
            FinishedMunchkinsOne.Add(new Munchkin(7, "Nick", MunchkinGender.Male, 3, 10));
            FinishedMunchkinsOne.Add(new Munchkin(9, "Tom", MunchkinGender.Male, 8, 15));
            FinishedMunchkinsOne.Add(new Munchkin(11, "Beau", MunchkinGender.Male, 4, 9));

            List<Munchkin> FinishedMunchkinsTwo = new List<Munchkin>();
            FinishedMunchkinsTwo.Add(new Munchkin(2, "Nicky", MunchkinGender.Female, 9, 15));
            FinishedMunchkinsTwo.Add(new Munchkin(4, "Mario", MunchkinGender.Female, 10, 11));
            FinishedMunchkinsTwo.Add(new Munchkin(6, "Sjoerd", MunchkinGender.Female, 6, 10));
            FinishedMunchkinsTwo.Add(new Munchkin(8, "Nick", MunchkinGender.Female, 6, 11));
            FinishedMunchkinsTwo.Add(new Munchkin(10, "Tom", MunchkinGender.Female, 2, 4));
            FinishedMunchkinsTwo.Add(new Munchkin(12, "Beau", MunchkinGender.Female, 7, 18));

            List<Munchkin> NewMunchkinsOne = new List<Munchkin>();
            NewMunchkinsOne.Add(new Munchkin(13, "Nicky", MunchkinGender.Male, 0, 0));
            NewMunchkinsOne.Add(new Munchkin(14, "Mario", MunchkinGender.Female, 0, 0));
            NewMunchkinsOne.Add(new Munchkin(15, "Sjoerd", MunchkinGender.Female, 0, 0));
            NewMunchkinsOne.Add(new Munchkin(16, "Nick", MunchkinGender.Male, 0, 0));
            NewMunchkinsOne.Add(new Munchkin(17, "Tom", MunchkinGender.Female, 0, 0));
            NewMunchkinsOne.Add(new Munchkin(18, "Beau", MunchkinGender.Male, 0, 0));

            List<Munchkin> NewMunchkinsTwo = new List<Munchkin>();
            NewMunchkinsTwo.Add(new Munchkin(19, "Nicky", MunchkinGender.Female, 0, 0));
            NewMunchkinsTwo.Add(new Munchkin(20, "Mario", MunchkinGender.Male, 0, 0));
            NewMunchkinsTwo.Add(new Munchkin(21, "Sjoerd", MunchkinGender.Male, 0, 0));
            NewMunchkinsTwo.Add(new Munchkin(22, "Nick", MunchkinGender.Female, 0, 0));
            NewMunchkinsTwo.Add(new Munchkin(23, "Tom", MunchkinGender.Male, 0, 0));
            NewMunchkinsTwo.Add(new Munchkin(24, "Beau", MunchkinGender.Female, 0, 0));

            List<Munchkin> PlayingMunchkinsOne = new List<Munchkin>();
            PlayingMunchkinsOne.Add(new Munchkin(25, "Nicky", MunchkinGender.Male, 5, 11));
            PlayingMunchkinsOne.Add(new Munchkin(26, "Mario", MunchkinGender.Female, 6, 12));
            PlayingMunchkinsOne.Add(new Munchkin(27, "Sjoerd", MunchkinGender.Male, 7, 15));
            PlayingMunchkinsOne.Add(new Munchkin(28, "Nick", MunchkinGender.Female, 5, 9));
            PlayingMunchkinsOne.Add(new Munchkin(29, "Tom", MunchkinGender.Male, 6, 7));
            PlayingMunchkinsOne.Add(new Munchkin(30, "Beau", MunchkinGender.Female, 8, 13));

            List<Munchkin> PlayingMunchkinsTwo = new List<Munchkin>();
            PlayingMunchkinsTwo.Add(new Munchkin(31, "Nicky", MunchkinGender.Female, 5, 11));
            PlayingMunchkinsTwo.Add(new Munchkin(32, "Mario", MunchkinGender.Male, 6, 12));
            PlayingMunchkinsTwo.Add(new Munchkin(33, "Sjoerd", MunchkinGender.Female, 7, 15));
            PlayingMunchkinsTwo.Add(new Munchkin(34, "Nick", MunchkinGender.Male, 5, 9));
            PlayingMunchkinsTwo.Add(new Munchkin(35, "Tom", MunchkinGender.Female, 6, 7));
            PlayingMunchkinsTwo.Add(new Munchkin(36, "Beau", MunchkinGender.Male, 8, 13));

            Munchkins = new List<Munchkin>();
            Munchkins.AddRange(FinishedMunchkinsOne);
            Munchkins.AddRange(FinishedMunchkinsTwo);
            Munchkins.AddRange(PlayingMunchkinsOne);
            Munchkins.AddRange(PlayingMunchkinsTwo);
            Munchkins.AddRange(NewMunchkinsOne);
            Munchkins.AddRange(NewMunchkinsTwo);

            Users = new List<User>();
            Users.Add(new User(1, "Nicky", "admin", "nicky@gmail.com"));
            Users.Add(new User(2, "Mario", "user", "mario@gmail.com"));
            Users.Add(new User(3, "Sjoerd", "user", "sjoerd@gmail.com"));
            Users.Add(new User(4, "Nick", "user", "nick@gmail.com"));
            Users.Add(new User(5, "Tom", "user", "tom@gmail.com"));
            Users.Add(new User(6, "Beau", "user", "beau@gmail.com"));

            Games = new List<Game>();

            Games.Add(new Game(1, GameStatus.Finished, DateTime.Now, FinishedMunchkinsOne, FinishedMunchkinsOne[2]));
            Games.Add(new Game(2, GameStatus.Finished, DateTime.Now, FinishedMunchkinsTwo, FinishedMunchkinsTwo[1]));
            Games.Add(new Game(3, GameStatus.Setup, DateTime.Now, NewMunchkinsOne));
            Games.Add(new Game(4, GameStatus.Setup, DateTime.Now, NewMunchkinsTwo));
            Games.Add(new Game(5, GameStatus.Playing, DateTime.Now, PlayingMunchkinsOne));
            Games.Add(new Game(6, GameStatus.Playing, DateTime.Now, PlayingMunchkinsTwo));
        }

        public User GetUserById(int id)
        {
            User user = null;

            foreach (User u in Users)
            {
                if (u.Id == id)
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
            return Games.Find(g => g.Id == id);
        }

        public List<Game> GetGamesByUser(User user)
        {
            List<Game> UserGames = new List<Game>();
            foreach (Munchkin m in Munchkins.FindAll(m => m.Name == user.Username))
            {
                UserGames.Add(Games.Find(g => g.Munchkins.Contains(m)));
            }

            return UserGames;
        }

        public IEnumerable<Game> GetAllGames()
        {
            return Games;
        }
        
        public Game AddGame(Game game, User user)
        {

        }

        public void RemoveGame()
        {

        }

        public Munchkin GetMunchkinById(int id)
        {
            return Munchkins.Find(m => m.Id == id);
        }

        public IEnumerable<Munchkin> GetMunchkinsByUser(User user)
        {
            return Munchkins.FindAll(m => m.Name == user.Username); 
        }

        public IEnumerable<Munchkin> GetAllMunchkins()
        {
            return Munchkins;
        }

        public Munchkin AddMunchkin(User user, Munchkin munchkin)
        {
            munchkin.Name = user.Username;
            munchkin.Id = Munchkins.Count + 1;
            Munchkins.Add(munchkin);

            return munchkin;
        }

        public void AddUser(User user)
        {
            user.Id = Users.Count + 1;
            Users.Add(user);
        }

        public void RemoveMunchkin(Munchkin munchkin)
        {
            Munchkins.Remove(munchkin);            
        }
    }
}
