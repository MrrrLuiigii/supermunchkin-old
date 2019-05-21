using Databases;
using Interfaces.Monsters;

namespace DAL.Contexts.Monsters
{
    public class MonsterContextSQL : IMonsterContext
    {
        private Database database = new Database();
    }
}
