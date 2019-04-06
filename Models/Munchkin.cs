using Models.Enums;

namespace Models
{
    public class Munchkin
    {
        public int Id { get; set; }
        public MunchkinGender Gender { get; set; }
        public int Level { get; set; }
        public int Gear { get; set; }

        public Munchkin(MunchkinGender gender)
        {
            Gender = gender;
        }

        public Munchkin(int id, MunchkinGender gender, int level, int gear)
        {
            Id = id;
            Gender = gender;
            Level = level;
            Gear = gear;
        }
    }
}
