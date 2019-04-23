using System;
using System.Collections.Generic;
using System.Data;
using DAL.Interfaces.Games;
using Databases;
using Models;
using Models.Enums;
using MySql.Data.MySqlClient;

namespace DAL.Contexts.Games
{
    public class GameContextSQL : IGameContext
    {
        private Database database = new Database();

        public void AddGame(Game game)
        {
            string sql =
                "insert into `game`(`Status`, `DateTime`)" +
                " values (@Status, @DateTime);";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@Status", game.Status));
            parameters.Add(new MySqlParameter("@DateTime", game.DateTimePlayed));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void AddMunchkin(Game game, Munchkin munchkin)
        {
            string sql =
                "insert into `munchkin-game`(`GameId`, `MunchkinId`)" +
                " values (@GameId, @MunchkinId);";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@GameId", game.Id));
            parameters.Add(new MySqlParameter("@MunchkinId", munchkin.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void AdjustGameStatus(Game game, GameStatus status)
        {
            string sql =
                "update `game`" +
                " set `Status` = @Status" +
                " where `GameId` = @GameId";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@Status", game.Status));
            parameters.Add(new MySqlParameter("@GameId", game.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public IEnumerable<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();

            string sql = "select * from `game`";

            DataTable dt = database.ExecuteQuery(sql);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int gameId = (int)dr["GameId"];
                    GameStatus status = (GameStatus)dr["Status"];
                    DateTime dateTime = (DateTime)dr["Level"];
                    int winnerId = (int)dr["WinnerId"];

                    Game game = new Game(gameId, status, dateTime, GetMunchkin(winnerId));
                    game = GetAllMunchkinsInGame(game);
                    games.Add(game);
                }
            }
            else
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            return games;
        }

        private Munchkin GetMunchkin(int winnerId)
        {
            Munchkin munchkin = null;

            string sql =
                "select `MunchkinId`, `UserId`, `Gender`, `Level`, `Gear`" +
                " from `munchkin`" +
                " where `MunchkinId` = @WinnerId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@WinnerId", winnerId));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int munchkinId = (int)dr["MunchkinId"];
                    string name = dr["Username"].ToString();
                    MunchkinGender gender = (MunchkinGender)dr["Gender"];
                    int level = (int)dr["Level"];
                    int gear = (int)dr["Gear"];

                    munchkin = new Munchkin(munchkinId, name, gender, level, gear);
                }
            }
            else
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            return munchkin;
        }

        private Game GetAllMunchkinsInGame(Game game)
        {
            List<Munchkin> munchkins = new List<Munchkin>();

            string sql =
                "select `munchkin.munchkinId`, `user.Username`, `munchkin.Gender`, `munchkin.Level`, `munchkin.Gear`" +
                " from `munchkin`" +
                " inner join `user`" +
                " on `munchkin.UserId` = `user.UserId`" +
                " inner join `munchkin-game`" +
                " on `munchkin-game`.`MunchkinId` = `munchkin`.`MunchkinId`";

            DataTable dt = database.ExecuteQuery(sql);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int munchkinId = (int)dr["MunchkinId"];
                    string name = dr["Username"].ToString();
                    MunchkinGender gender = (MunchkinGender)dr["Gender"];
                    int level = (int)dr["Level"];
                    int gear = (int)dr["Gear"];

                    Munchkin munchkin = new Munchkin();
                    game = GetAllMunchkinsInGame(game);
                }
            }
            else
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            game.Munchkins = munchkins;
            return game;
        }

        public void RemoveMunchkin(Game game, Munchkin munchkin)
        {
            string sql =
                "delete from `munchkin`" +
                " where `MunchkinId` = @MunchkinId";

            if (database.ExecuteQueryWithStatus(sql, new MySqlParameter("@MunchkinId", munchkin.Id)) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            RemoveMunchkinFromGame(game, munchkin);
        }

        private void RemoveMunchkinFromGame(Game game, Munchkin munchkin)
        {
            string sql =
                "delete from `munchkin-game`" +
                " where `GameId` = @GameId" +
                " and `MunchkinId` = @MunchkinId";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@GameId", game.Id));
            parameters.Add(new MySqlParameter("@MunchkinId", munchkin.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void SetWinner(Game game, Munchkin munchkin)
        {
            string sql =
                "update `game`" +
                " set `WinnerId` = @WinnerId" +
                " where `GameId` = @GameId";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@WinnerId", munchkin.Id));
            parameters.Add(new MySqlParameter("@GameId", game.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }
    }
}
