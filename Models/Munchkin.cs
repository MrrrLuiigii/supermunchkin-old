using Models.Enums;

namespace Models
{
    public class Munchkin
    {
        public int Id { get; set; }
        public MunchkinGender Gender { get; set; }
        public int Level { get; set; }
        public int Gear { get; set; }
    }
}
