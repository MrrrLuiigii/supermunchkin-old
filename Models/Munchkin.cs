using Models.Enums;
using Newtonsoft.Json;

namespace Models
{
    public class Munchkin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MunchkinGender? Gender { get; set; }
        public int Level { get; set; }
        public int Gear { get; set; }
        public int Modifier { get; set; }

        public Munchkin()
        {

        }

        public Munchkin(string name, MunchkinGender? gender)
        {
            Name = name;
            Gender = gender;
            Level = 1;
            Gear = 0;
        }
        
        [JsonConstructor]
        public Munchkin(int id, string name, MunchkinGender gender, int level, int gear)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Level = level;
            Gear = gear;
        }
    }
}
