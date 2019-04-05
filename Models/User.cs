using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<IMunchkin> Munchkins { get; set; }
    }
}
