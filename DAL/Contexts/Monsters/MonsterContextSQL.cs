using Databases;
using Interfaces.Monsters;
using Models;
using Models.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

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

        public int CreateMonster(Monster monster)
        {
            string sp = "AddMonster";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("pLevel", monster.Level));

            MySqlParameter output = new MySqlParameter("pOutId", MySqlDbType.Int32);
            output.Direction = ParameterDirection.Output;
            parameters.Add(output);

            return database.ExecuteStoredProcedureWithOutput(sp, new MySqlParameter("pLevel", monster.Level));
        }

        public List<Monster> GetAllMonstersByBattle(Battle battle)
        {
            List<Monster> monsters = new List<Monster>();

            string sql =
                "select `monster`.`MonsterId`, `monster`.`Level`, `monster`.`Modifier`" +
                "from `monster`" +
                "inner join `monster-battle`" +
                "on `monster`.`MonsterId` = `monster-battle`.`MonsterId`" +
                "where `monster-battle`.`BattleId` = @BattleId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@BattleId", battle.Id));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int monsterId = (int)dr["MonsterId"];
                    int level = (int)dr["Level"];
                    int modifier = (int)dr["Modifier"];

                    Monster monster = new Monster(monsterId, level, modifier);
                    monsters.Add(monster);
                }
            }
            else
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            return monsters;
        }

        public Monster GetMonsterById(int id)
        {
            Monster monster = null;

            string sql =
                "select `monster`.`MonsterId`, `monster`.`Level`, `monster`.`Modifier`" +
                "from `monster`" +
                "inner join `monster-battle`" +
                "on `monster`.`MonsterId` = `monster-battle`.`MonsterId`" +
                "where `monster`.`MonsterId` = @MonsterId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@MonsterId", id));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int monsterId = (int)dr["MonsterId"];
                    int level = (int)dr["Level"];
                    int modifier = (int)dr["Modifier"];

                    monster = new Monster(monsterId, level, modifier);
                }
            }
            else
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            return monster;
        }

        public void RemoveMonster(Monster monster)
        {
            string sp = "RemoveMonster";

            if (database.ExecuteStoredProcedure(sp, new MySqlParameter("pMonsterId", monster.Id)) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }
    }
}
