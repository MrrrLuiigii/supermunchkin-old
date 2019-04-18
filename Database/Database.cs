using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Databases
{
    public enum ExecuteStatus
    {
        Error,
        OK
    }

    public class Database
    {
        private MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=supermunchkin");

        public DataTable ExecuteQuery(string query)
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, conn);
            DataTable dt = new DataTable();

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch
            {
                dt = null;
            }

            conn.Close();

            return dt;
        }

        public DataTable ExecuteQuery(string query, List<MySqlParameter> parameters = null)
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, conn);

            foreach (MySqlParameter sqlp in parameters)
            {
                cmd.Parameters.Add(sqlp);
            }

            DataTable dt = new DataTable();

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch
            {
                dt = null;
            }


            conn.Close();

            return dt;
        }

        public DataTable ExecuteQuery(string query, MySqlParameter parameter = null)
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, conn);

            if (parameter != null)
            {
                cmd.Parameters.Add(parameter);
            }

            DataTable dt = new DataTable();

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            catch
            {
                dt = null;
            }


            conn.Close();

            return dt;
        }

        public ExecuteStatus ExecuteStatusQuery(string query, List<MySqlParameter> parameters)
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, conn);

            foreach (MySqlParameter sqlp in parameters)
            {
                cmd.Parameters.Add(sqlp);
            }

            ExecuteStatus status = ExecuteStatus.OK;


            cmd.ExecuteReader();
            status = ExecuteStatus.OK;


            conn.Close();

            return status;
        }

        public ExecuteStatus ExecuteStatusQuery(string query, MySqlParameter parameter)
        {
            conn.Open();

            MySqlCommand cmd = new MySqlCommand(query, conn);

            if (parameter != null)
            {
                cmd.Parameters.Add(parameter);
            }

            ExecuteStatus status = ExecuteStatus.OK;

            try
            {
                cmd.ExecuteReader();
                status = ExecuteStatus.OK;
            }
            catch
            {
                status = ExecuteStatus.Error;
            }

            conn.Close();

            return status;
        }
    }
}
