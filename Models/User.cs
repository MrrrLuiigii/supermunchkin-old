using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<Munchkin> Munchkins { get; set; }

        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public User(int id, string username, string password, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Email = email;
        }

        public User(int id, string username, string password, string email, IEnumerable<Munchkin> munchkins) : this(id, username, password, email)
        {
            Munchkins = munchkins;
        }
    }
}
