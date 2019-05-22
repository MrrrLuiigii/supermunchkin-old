using Databases;
using Interfaces.Monsters;
using Models;
using Models.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL.Contexts.Monsters
{
    public class MonsterContextSQL : IMonsterContext
    {
        private Database database = new Database();

        public void AdjustMonster(Monster monster)
        {
            string sp = "AdjustMonster";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("pMonsterId", monster.Id));
            parameters.Add(new MySqlParameter("pLevel", monster.Level));
            parameters.Add(new MySqlParameter("pModifier", monster.Modifier));

            if (database.ExecuteStoredProcedure(sp, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }
    }
}
