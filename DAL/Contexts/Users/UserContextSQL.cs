using System;
using System.Collections.Generic;
using System.Data;
using DAL.Interfaces.Users;
using Databases;
using Models;
using Models.Enums;
using MySql.Data.MySqlClient;

namespace DAL.Contexts.Users
{
    public class UserContextSQL : IUserContext
    {
        private Database database = new Database();

        public void AddMunchkin(User user, Munchkin munchkin)
        {
            string sql =
                "insert into `munchkin` (`UserId`, `Gender`, `Level`, `Gear`)" +
                " values (@UserId, @Gender, @Level, @Gear);";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@UserId", user.Id));
            parameters.Add(new MySqlParameter("@Gender", munchkin.Gender));
            parameters.Add(new MySqlParameter("@Level", munchkin.Level));
            parameters.Add(new MySqlParameter("@Gear", munchkin.Gear));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public void AddUser(User user)
        {
            string sql =
                "insert into `user`(`Username`, `Password`, `Email`)" +
                " values (@Username, @Password, @Email);";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter("@Username", user.Username));
            parameters.Add(new MySqlParameter("@Password", user.Password));
            parameters.Add(new MySqlParameter("@Email", user.Email));

            if (database.ExecuteQueryWithStatus(sql, parameters) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }

        public IEnumerable<Munchkin> GetAllMunchkins()
        {
            List<Munchkin> munchkins = new List<Munchkin>();

            string sql =
                "select `munchkin.munchkinId`, `user.Username`, `munchkin.Gender`, `munchkin.Level`, `munchkin.Gear`" +
                " from `munchkin`" +
                " inner join `user`" +
                " on `munchkin.UserId` = `user.UserId`";

            DataTable dt = database.ExecuteQuery(sql);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int munchkinId = (int)dr["MunchkinId"];
                    string name = dr["UserId"].ToString();

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

            return munchkins;
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            string sql = "select * from `user`";

            DataTable dt = database.ExecuteQuery(sql);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int userId = (int)dr["UserId"];
                    string username = dr["Username"].ToString();
                    string password = dr["Password"].ToString();
                    string email = dr["Email"].ToString();

                    User user = new User(userId, username, password, email);
                    users.Add(user);
                }
            }
            else
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }

            return users;
        }

        public void RemoveMunchkin(Munchkin munchkin)
        {
            string sql = 
                "delete from `munchkin` " +
                "where `MunchkinId` = @munchkinId";

            if (database.ExecuteQueryWithStatus(sql, new MySqlParameter("@munchkinId", munchkin.Id)) != ExecuteQueryStatus.OK)
            {
                throw new Exception("Something went wrong. Sorry for the inconvenience.");
            }
        }
    }
}
