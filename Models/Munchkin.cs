using Models.Enums;
using Models.Interfaces;

namespace Models
{
    public class Munchkin : IMunchkin
    {
        public int Id { get; set; }
        public MunhckinGender Gender { get; set; }
        public int Level { get; set; }
        public int Gear { get; set; }
    }
}
