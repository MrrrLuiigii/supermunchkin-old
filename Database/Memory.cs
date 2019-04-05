using Models;
using System.Collections.Generic;

namespace Database
{
    public class Memory
    {
        public List<User> Users;

        public Memory()
        {
            Users = new List<User>();

            Users.Add(new User(1, "Nicky", "admin", "nicky@gmail.com"));
            Users.Add(new User(2, "Mario", "user", "mario@gmail.com"));
            Users.Add(new User(3, "Sjoerd", "user", "sjoerd@gmail.com"));
            Users.Add(new User(4, "Nick", "user", "nick@gmail.com"));
            Users.Add(new User(5, "Tom", "user", "tom@gmail.com"));
            Users.Add(new User(6, "Beau", "user", "beau@gmail.com"));
        }
    }
}
