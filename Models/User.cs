using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Munchkin> Munchkins { get; set; }

        public User(string username, string password, string email)
        {
            Munchkins = new List<Munchkin>();

            Username = username;
            Password = password;
            Email = email;
        }

        public User(int id, string username, string password, string email)
        {
            Munchkins = new List<Munchkin>();

            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        [JsonConstructor]
        public User(int id, string username, string password, string email, List<Munchkin> munchkins) : this(id, username, password, email)
        {
            Munchkins = new List<Munchkin>();

            Munchkins = munchkins;
        }
    }
}
