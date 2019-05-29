using Databases;
using Interfaces.Battles;
using Models;
using Models.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL.Contexts.Battles
{
    public class BattleContextSQL : IBattleContext
    {
        private Database database = new Database();

        public void AddMonster(Battle battle, Monster monster)
        {
            string sql = 
                "insert into `monster-battle`(`BattleId`, `MonsterId`, `Modifier`)" +
                "values (@BattleId, @MonsterId, @Modifier)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@BattleId", battle.Id));
            parameters.Add(new MySqlParameter("@MonsterId", monster.Id));
            parameters.Add(new MySqlParameter("@Modifier", monster.Modifier));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void AddMunchkin(Battle battle, Munchkin munchkin)
        {
            string sql = 
                "insert into `munchkin-battle`(`BattleId`, `MunchkinId`, `Modifier`)" +
                "values (@BattleId, @MunchkinId, @Modifier)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@BattleId", battle.Id));
            parameters.Add(new MySqlParameter("@MonsterId", munchkin.Id));
            parameters.Add(new MySqlParameter("@Modifier", munchkin.Modifier));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void AdjustBattleStatus(Battle battle)
        {
            string sql =
                "update `battle`" +
                "set `Status` = @Status" +
                "where `BattleId` = @BattleId";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@Status", battle.Status));
            parameters.Add(new MySqlParameter("@BattleId", battle.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void RemoveMonster(Battle battle, Monster monster)
        {
            string sp = "RemoveMonster";

            if (database.ExecuteStoredProcedure(sp, new MySqlParameter("pMonsterId", monster.Id)) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void RemoveMunchkin(Battle battle, Munchkin munchkin)
        {
            string sql = 
                "delete from `munchkin-battle`" +
                "where `MunchkinId` = @MunchkinId" +
                "and `BattleId`= @BattleId";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@MunchkinId", munchkin.Id));
            parameters.Add(new MySqlParameter("@BattleId", battle.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }
    }
}
