using DAL.Interfaces.Munchkins;
using Database;
using Models;
using Models.Enums;

namespace DAL.Contexts.Munchkins
{
    public class MunchkinContextMemory : IMunchkinContext
    {
        Memory memory = new Memory();

        public void AdjustMunchkin(Munchkin munchkin)
        {
            //Update munchkin
        }
    }
}
