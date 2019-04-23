using DAL.Interfaces.Munchkins;
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
            string sql = $"update `munchkin` set `Gender` = @Gender, `Level` = @Level, `Gear` = @Gear where `MunchkinId` = @MunchkinId";

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
    }
}
