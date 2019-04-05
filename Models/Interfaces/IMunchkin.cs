using Models.Enums;

namespace Models.Interfaces
{
    public interface IMunchkin
    {
        int Id { get; set; }
        MunchkinGender Gender { get; set; }
        int Level { get; set; }
        int Gear { get; set; }
    }
}
