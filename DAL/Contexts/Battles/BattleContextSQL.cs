using Databases;
using Interfaces.Battles;

namespace DAL.Contexts.Battles
{
    public class BattleContextSQL : IBattleContext
    {
        private Database database = new Database();
    }
}
