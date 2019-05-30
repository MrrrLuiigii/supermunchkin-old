using Interfaces.Munchkins;
using Databases;
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

        public void AdjustMunchkin(Munchkin munchkin, Battle battle)
        {
            throw new System.NotImplementedException();
        }
    }
}
