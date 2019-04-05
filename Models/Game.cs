<<<<<<< HEAD
﻿using Models.Enums;
using System;
=======
﻿using System;
using System.Collections.Generic;
using Models.Enums;
using Models.Interfaces;
>>>>>>> parent of b64d1f3... Removing Model Interfaces

namespace Models
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public GameStatus Status { get; set; }
        public DateTime DatePlayed { get; set; }
<<<<<<< HEAD
        public Munchkin Winner { get; set; }
=======
        public IEnumerable<IMunchkin> Munchkins { get; set; }
        public IMunchkin Winner { get; set; }
>>>>>>> parent of b64d1f3... Removing Model Interfaces
    }
}
