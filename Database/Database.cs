using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using Models.Enums;
using System;

namespace Databases
{
    public class Database : DatabaseConnection
    {
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public DataTable ExecuteQuery(string sql)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);
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

        public DataTable ExecuteQuery(string sql, List<MySqlParameter> parameters = null)
        {
            conn.Open();

            cmd = new MySqlCommand(sql, conn);

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

        public DataTable ExecuteQuery(string sql, MySqlParameter parameter = null)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);

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

        public ExecuteQueryStatus ExecuteQueryWithStatus(string sql, List<MySqlParameter> parameters)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);

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

        public ExecuteQueryStatus ExecuteQueryWithStatus(string sql, MySqlParameter p)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);

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

        public ExecuteQueryStatus ExecuteStoredProcedure(string procedureName, MySqlParameter parameter)
        {
            conn.Open();
            cmd = new MySqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(parameter);

            ExecuteQueryStatus status = ExecuteQueryStatus.OK;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                status = ExecuteQueryStatus.Error;
            }

            cmd.Dispose();
            conn.Close();
            return status;
        }

        public int ExecuteStoredProcedure(string procedureName, List<MySqlParameter> parameters)
        {
            conn.Open();
            cmd = new MySqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (MySqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            int id = 0;

            try
            {
                cmd.ExecuteNonQuery();
                id = (int)cmd.Parameters["pOutId"].Value;
            }
            catch(Exception ex)
            {
                id = 0;
            }

            cmd.Dispose();
            conn.Close();

            return id;
        }
    }
}
