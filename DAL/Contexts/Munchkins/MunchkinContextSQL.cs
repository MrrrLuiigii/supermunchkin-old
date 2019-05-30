using Interfaces.Munchkins;
using Databases;
using Models;
using Models.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace DAL.Contexts.Munchkins
{
    public class MunchkinContextSQL : IMunchkinContext
    {
        private Database database = new Database();

        public void AdjustMunchkin(Munchkin munchkin)
        {
            string sql = 
                "update `munchkin`" +
                " set `Gender` = @Gender, `Level` = @Level, `Gear` = @Gear" +
                " where `MunchkinId` = @MunchkinId";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@Gender", munchkin.Gender));
            parameters.Add(new MySqlParameter("@Level", munchkin.Level));
            parameters.Add(new MySqlParameter("@Gear", munchkin.Gear));
            parameters.Add(new MySqlParameter("@MunchkinId", munchkin.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void AdjustMunchkin(Munchkin munchkin, Battle battle)
        {
            string sp = "AdjustMunchkin";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("pGender", munchkin.Gender));
            parameters.Add(new MySqlParameter("pLevel", munchkin.Level));
            parameters.Add(new MySqlParameter("pGear", munchkin.Gear));
            parameters.Add(new MySqlParameter("pMunchkinId", munchkin.Id));
            parameters.Add(new MySqlParameter("pModifier", munchkin.Modifier));
            parameters.Add(new MySqlParameter("pBattleId", battle.Id));

            if (database.ExecuteStoredProcedure(sp, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }
    }
}
