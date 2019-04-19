using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using Models.Enums;

namespace Databases
{
    public class Database
    {
        private MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=supermunchkin");
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public DataTable ExecuteQuery(string query)
        {
            conn.Open();
            cmd = new MySqlCommand(query, conn);
            DataTable dt = new DataTable();

            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch
            {
                dt = null;
            }
            
            cmd.Dispose();
            conn.Close();
            return dt;
        }

        public DataTable ExecuteQuery(string query, List<MySqlParameter> parameters = null)
        {
            conn.Open();

            cmd = new MySqlCommand(query, conn);

            foreach (MySqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            DataTable dt = new DataTable();

            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch
            {
                dt = null;
            }

            cmd.Dispose();
            conn.Close();
            return dt;
        }

        public DataTable ExecuteQuery(string query, MySqlParameter parameter = null)
        {
            conn.Open();
            cmd = new MySqlCommand(query, conn);

            if (parameter != null)
            {
                cmd.Parameters.Add(parameter);
            }

            DataTable dt = new DataTable();

            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch
            {
                dt = null;
            }

            cmd.Dispose();
            conn.Close();
            return dt;
        }

        public ExecuteQueryStatus ExecuteQueryWithStatus(string query, List<MySqlParameter> parameters)
        {
            conn.Open();
            cmd = new MySqlCommand(query, conn);

            foreach (MySqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            ExecuteQueryStatus status = ExecuteQueryStatus.OK;

            try
            {
                cmd.ExecuteReader();
            }
            catch
            {
                status = ExecuteQueryStatus.Error;
            }

            cmd.Dispose();
            conn.Close();
            return status;
        }

        public ExecuteQueryStatus ExecuteQueryWithStatus(string query, MySqlParameter p)
        {
            conn.Open();
            cmd = new MySqlCommand(query, conn);

            if (p != null)
            {
                cmd.Parameters.Add(p);
            }

            ExecuteQueryStatus status = ExecuteQueryStatus.OK;

            try
            {
                cmd.ExecuteReader();
            }
            catch
            {
                status = ExecuteQueryStatus.Error;
            }
            
            cmd.Dispose();
            conn.Close();
            return status;
        }
    }
}
