using System;
using System.Collections.Generic;
using System.Data;
using Interfaces.Games;
using Databases;
using Models;
using Models.Enums;
using MySql.Data.MySqlClient;

namespace DAL.Contexts.Games
{
    public class GameContextSQL : IGameContext
    {
        private Database database = new Database();

        public Game AddGame(Game game, User user)
        {
            string sp = "AddGame";
            DateTime dateAndTime = Convert.ToDateTime(game.DateTimePlayed.ToString("yyyy-MM-dd HH:mm:ss"));

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("pStatus", game.Status));                        
            parameters.Add(new MySqlParameter("pDateTime", dateAndTime));
            parameters.Add(new MySqlParameter("pUserId", user.Id));

            MySqlParameter output = new MySqlParameter("pOutId", MySqlDbType.Int32);
            output.Direction = ParameterDirection.Output;
            parameters.Add(output);

            return GetGameById(database.ExecuteStoredProcedureWithOutput(sp, parameters));
        }

        public Game GetGameById(int id)
        {
            Game game = null;

            string sql =
                "select *" +
                " from `game`" +
                " where `GameId` = @GameId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@GameId", id));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int gameId = (int)dr["GameId"];

                    GameStatus status = GameStatus.Setup;
                    if (dr["Status"].ToString() == "Playing")
                    {
                        status = GameStatus.Playing;
                    }
                    else if (dr["Status"].ToString() == "Finished")
                    {
                        status = GameStatus.Finished;
                    }

                    DateTime dateTime = (DateTime)dr["DateTime"];

                    int winnerId = -1;
                    if (dr["WinnerId"] != DBNull.Value)
                    {
                        winnerId = (int)dr["WinnerId"];
                    }

                    game = new Game(gameId, status, dateTime, GetMunchkin(winnerId));
                    game = GetAllMunchkinsInGame(game);
                }
            }
            else
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            return game;
        }

        private Game GetGameByDateTimeAndStatus(Game game)
        {
            string sql = 
                "select *" +
                " from `game`" +
                " where `DateTime` = @DateTime" +
                " and `Status` = @Status";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@DateTime", Convert.ToDateTime(game.DateTimePlayed.ToString("yyyy-MM-dd HH:mm:ss"))));
            parameters.Add(new MySqlParameter("@Status", game.Status));

            DataTable dt = database.ExecuteQuery(sql, parameters);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int gameId = (int)dr["GameId"];

                    GameStatus status = GameStatus.Setup;
                    if (dr["Status"].ToString() == "Playing")
                    {
                        status = GameStatus.Playing;
                    }
                    else if (dr["Status"].ToString() == "Finished")
                    {
                        status = GameStatus.Finished;
                    }

                    DateTime dateTime = (DateTime)dr["DateTime"];

                    int winnerId = -1;
                    if (dr["WinnerId"] != DBNull.Value)
                    {
                        winnerId = (int)dr["WinnerId"];
                    }

                    game = new Game(gameId, status, dateTime, GetMunchkin(winnerId));
                    game = GetAllMunchkinsInGame(game);
                }
            }
            else
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            return game;
        }

        private void AddGameToUser(Game game, User user)
        {
            string sql =
                "insert into `user-game`(`GameId`, `UserId`)" +
                " values (@GameId, @UserId)";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@GameId", game.Id));
            parameters.Add(new MySqlParameter("@UserId", user.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void AddMunchkin(Game game, Munchkin munchkin)
        {
            string sql =
                "insert into `munchkin-game`(`GameId`, `MunchkinId`)" +
                " values (@GameId, @MunchkinId)";

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
            parameters.Add(new MySqlParameter("@Status", status));
            parameters.Add(new MySqlParameter("@GameId", game.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();

            string sql = "select * from `game`";

            DataTable dt = database.ExecuteQuery(sql);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int gameId = (int)dr["GameId"];

                    GameStatus status = GameStatus.Setup;
                    if (dr["Status"].ToString() == "Playing")
                    {
                        status = GameStatus.Playing;
                    }
                    else if (dr["Status"].ToString() == "Finished")
                    {
                        status = GameStatus.Finished;
                    }

                    DateTime dateTime = (DateTime)dr["DateTime"];

                    int winnerId = -1;
                    if (dr["WinnerId"] != DBNull.Value)
                    {
                        winnerId = (int)dr["WinnerId"];
                    }

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

        public List<Game> GetAllGamesByUser(User user)
        {
            List<Game> games = new List<Game>();

            string sql = 
                "select *" +
                " from `game`" +
                " inner join `user-game`" +
                " on `game`.`GameId` = `user-game`.`GameId`" +
                " where `user-game`.`UserId` = @UserId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@UserId", user.Id));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int gameId = (int)dr["GameId"];

                    GameStatus status = GameStatus.Setup;
                    if (dr["Status"].ToString() == "Playing")
                    {
                        status = GameStatus.Playing;
                    }
                    else if (dr["Status"].ToString() == "Finished")
                    {
                        status = GameStatus.Finished;
                    }

                    DateTime dateTime = (DateTime)dr["DateTime"];

                    int winnerId = -1;
                    if (dr["WinnerId"] != DBNull.Value)
                    {
                        winnerId = (int)dr["WinnerId"];
                    }

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
                "select `munchkin`.`MunchkinId`, `user`.`Username`, `munchkin`.`Gender`, `munchkin`.`Level`, `munchkin`.`Gear`" +
                " from `munchkin`" +
                " inner join `user`" +
                " on `munchkin`.`UserId` = `user`.`UserId`" +
                " where `MunchkinId` = @WinnerId";                

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@WinnerId", winnerId));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int munchkinId = (int)dr["MunchkinId"];
                    string name = dr["Username"].ToString();

                    MunchkinGender gender = MunchkinGender.Male;
                    if (dr["Gender"].ToString() == "Female")
                    {
                        gender = MunchkinGender.Female;
                    }

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
                "select `munchkin`.`MunchkinId`, `user`.`Username`, `munchkin`.`Gender`, `munchkin`.`Level`, `munchkin`.`Gear`" +
                " from `munchkin`" +
                " inner join `user`" +
                " on `munchkin`.`UserId` = `user`.`UserId`" +
                " inner join `munchkin-game`" +
                " on `munchkin-game`.`MunchkinId` = `munchkin`.`MunchkinId`" +
                $" where `munchkin-game`.`GameId` = {game.Id}";

            DataTable dt = database.ExecuteQuery(sql);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int munchkinId = (int)dr["MunchkinId"];
                    string name = dr["Username"].ToString();

                    MunchkinGender gender = MunchkinGender.Male;
                    if (dr["Gender"].ToString() == "Female")
                    {
                        gender = MunchkinGender.Female;
                    }

                    int level = (int)dr["Level"];
                    int gear = (int)dr["Gear"];

                    Munchkin munchkin = new Munchkin(munchkinId, name, gender, level, gear);
                    munchkins.Add(munchkin);
                }
            }
            else
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            game.Munchkins = munchkins;
            return game;
        }

        public void RemoveGame(Game game)
        {
            string sp = "RemoveGame";

            if (database.ExecuteStoredProcedure(sp, new MySqlParameter("pGameId", game.Id)) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }            
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

        public void AddBattle(Game game, Battle battle)
        {
            throw new NotImplementedException();
        }

        public void RemoveBattle(Game game, Battle battle)
        {
            string sql =
                "delete from `battle`" +
                "where `BattleId` = @BattleId" +
                "and `GameId` = @GameId";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@BattleId", battle.Id));
            parameters.Add(new MySqlParameter("@GameId", game.Id));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public List<Battle> GetAllBattlesByGame(Game game)
        {
            List<Battle> battles = new List<Battle>();

            string sql =
                "select `BattleId`, `Status`, `DateTime`" +
                "from `Battle`" +
                "where `GameId` = @GameId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@GameId", game.Id));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int battleId = (int)dr["BattleId"];

                    BattleStatus battleStatus = BattleStatus.Ongoing;
                    if (dr["Status"].ToString() == "Lost")
                    {
                        battleStatus = BattleStatus.Lost;
                    }
                    else if (dr["Status"].ToString() == "Won")
                    {
                        battleStatus = BattleStatus.Won;
                    }

                    DateTime dateTime = (DateTime)dr["DateTime"];

                    Battle battle = new Battle(battleId, battleStatus, dateTime);
                    battle.Munchkins = GetAllMunchkinsInBattle(battleId);
                    battle.Monsters = GetAllMonstersInBattle(battleId);

                    battles.Add(battle);
                }
            }

            return battles;
        }

        private List<Munchkin> GetAllMunchkinsInBattle(int battleId)
        {
            List<Munchkin> munchkins = new List<Munchkin>();

            string sql =
                "select `munchkin`.`MunchkinId`, `user`.`Username`, `munchkin`.`Gender`, `munchkin`.`Level`, `munchkin`.`Gear`, `munchkin-battle`.`Modifier`" +
                "from `munchkin`" +
                "inner join `user`" +
                "on `munchkin`.`UserId` = `user`.`UserId`" +
                "inner join `muchkin-battle`" +
                "on `munchkin`.`MunchkinId` = `munchkin-battle`.`MunchkinId`" +
                "where `munchkin-battle`.`BattleId` = @BattleId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@BattleId", battleId));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int munchkinId = (int)dr["MunchkinId"];
                    string name = dr["Username"].ToString();

                    MunchkinGender gender = MunchkinGender.Male;
                    if (dr["Gender"].ToString() == "Female")
                    {
                        gender = MunchkinGender.Female;
                    }

                    int level = (int)dr["Level"];
                    int gear = (int)dr["Gear"];
                    int modifier = (int)dr["Modifier"];

                    Munchkin munchkin = new Munchkin(munchkinId, name, gender, level, gear, modifier);
                    munchkins.Add(munchkin);
                }
            }

            return munchkins;
        }

        private List<Monster> GetAllMonstersInBattle(int battleId)
        {
            List<Monster> monsters = new List<Monster>();

            string sql =
                "select `monster`.`MonsterId`, `monster`.`Level`, `monster-battle`.`Modifier`" +
                "from `monster`" +
                "inner join `monster-battle`" +
                "on `monster`.`MonsterId` = `monster-battle`.`MonsterId`" +
                "where `monster-battle`.`BattleId` = @BattleId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@BattleId", battleId));

            if (dt != null)
            {
                int monstername = 1;

                foreach (DataRow dr in dt.Rows)
                {
                    int monsterId = (int)dr["MonsterId"];
                    int level = (int)dr["Level"];
                    int modifier = (int)dr["Modifier"];

                    Monster monster = new Monster(monsterId, "Monster" + monstername, level, modifier);
                    monsters.Add(monster);
                    monstername += 1;
                }
            }

            return monsters;
        }

        public Battle GetBattleById(int id)
        {
            Battle battle = null;

            string sql =
                "select `BattleId`, `Status`, `DateTime`" +
                "from `Battle`" +                
                "where `BattleId` = @BattleId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@BattleId", id));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int battleId = (int)dr["BattleId"];

                    BattleStatus battleStatus = BattleStatus.Ongoing;
                    if (dr["Status"].ToString() == "Lost")
                    {
                        battleStatus = BattleStatus.Lost;
                    }
                    else if (dr["Status"].ToString() == "Won")
                    {
                        battleStatus = BattleStatus.Won;
                    }

                    DateTime dateTime = (DateTime)dr["DateTime"];

                    battle = new Battle(battleId, battleStatus, dateTime);
                    battle.Munchkins = GetAllMunchkinsInBattle(battleId);
                    battle.Monsters = GetAllMonstersInBattle(battleId);
                }
            }

            return battle;
        }

        public List<Battle> GetAllBattlesByMunchkin(Munchkin munchkin)
        {
            List<Battle> battles = new List<Battle>();

            string sql =
                "select `Battle`.`BattleId`, `Battle`.`Status`, `Battle`.`DateTime`" +
                "from `Battle`" +
                "inner join `munchkin-battle`" +
                "on `battle`.`BattleId` = `munchkin-battle`.`BattleId" +
                "where `MunchkinId` = @MunchkinId";

            DataTable dt = database.ExecuteQuery(sql, new MySqlParameter("@MunchkinId", munchkin.Id));

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int battleId = (int)dr["BattleId"];

                    BattleStatus battleStatus = BattleStatus.Ongoing;
                    if (dr["Status"].ToString() == "Lost")
                    {
                        battleStatus = BattleStatus.Lost;
                    }
                    else if (dr["Status"].ToString() == "Won")
                    {
                        battleStatus = BattleStatus.Won;
                    }

                    DateTime dateTime = (DateTime)dr["DateTime"];

                    Battle battle = new Battle(battleId, battleStatus, dateTime);
                    battle.Munchkins = GetAllMunchkinsInBattle(battleId);
                    battle.Monsters = GetAllMonstersInBattle(battleId);

                    battles.Add(battle);
                }
            }

            return battles;
        }
    }
}
