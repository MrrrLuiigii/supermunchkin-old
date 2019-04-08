using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Database
    {
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public Database()
        {
            EstablishConnection();
        }

        private void EstablishConnection()
        {
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=;database=supermunchkin";

            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = myConnectionString;
            }
            catch (MySqlException ex)
            {
                ex.ToString();
            }
        }

        /// <summary>
        /// Format the SQL string for reading from the database.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private string GenerateReadQuery(string[] arguments, string table)
        {
            string sql = "select ";

            for (int i = 0; i < arguments.Length; i++)
            {
                sql += string.Format("{0}", arguments[i]);

                if (i + 1 < arguments.Length)
                {
                    sql += ", ";
                }
            }

            sql += string.Format(" from {0}", table);

            return sql;
        }

        /// <summary>
        /// Adds a WHERE clause to the SQL string for reading from the database.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        private string GenerateReadWhereQuery(string[] arguments, string table, string[] where)
        {
            string sql = GenerateReadQuery(arguments, table) + " where ";

            for (int i = 0; i < where.Length; i++)
            {
                sql += string.Format("{0}", where[i]);

                if (i + 1 < where.Length)
                {
                    sql += string.Format(" and ");
                }
            }

            return sql;
        }

        /// <summary>
        /// Selects the type of read query that has to be made.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<string> Read(string[] arguments, string table)
        {
            string sql = GenerateReadQuery(arguments, table);
            return ReadFromDatabase(arguments, sql);
        }

        /// <summary>
        /// Selects the type of read query that has to be made.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<string> Read(string[] arguments, string table, string[] where)
        {
            string sql = GenerateReadWhereQuery(arguments, table, where);
            return ReadFromDatabase(arguments, sql);
        }

        /// <summary>
        /// Read from the database with the given SQL string.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        private List<string> ReadFromDatabase(string[] arguments, string sql)
        {
            List<string> Output = new List<string>();

            conn.Open();
            cmd = new MySqlCommand(sql, conn);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                try
                {
                    string temp = "";
                    for (int i = 0; i < arguments.Length; i++)
                    {
                        temp += reader.GetValue(i);

                        if (i + 1 < arguments.Length)
                        {
                            temp += " ;; ";
                        }
                    }

                    Output.Add(temp);
                }
                catch (Exception)
                {
                }
            }

            reader.Close();
            cmd.Dispose();
            conn.Close();

            return Output;
        }

        /// <summary>
        /// Format the SQL string for writing to the database.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        private string FormatWriteSQL(string table, string[] arguments)
        {
            string sql = string.Format("Insert into {0} (", table);
            for (int i = 0; i < arguments.Length; i++)
            {
                sql += string.Format("{0}", arguments[i]);

                if (i + 1 < arguments.Length)
                {
                    sql += ", ";
                }
            }
            sql += ") values (";

            for (int i = 0; i < arguments.Length; i++)
            {
                sql += string.Format("@{0}", arguments[i]);

                if (i + 1 < arguments.Length)
                {
                    sql += ", ";
                }
            }
            sql += ")";

            return sql;
        }

        /// <summary>
        /// Write to the database.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="arguments"></param>
        /// <param name="values"></param>
        public void Write(string table, string[] arguments, string[] values)
        {
            bool notEmpty = false;
            string sql = FormatWriteSQL(table, arguments);

            conn.Open();

            cmd = new MySqlCommand(sql, conn);

            using (cmd = new MySqlCommand(sql, conn))
            {
                for (int i = 0; i < arguments.Length; i++)
                {
                    if (values[i] != "")
                    {
                        cmd.Parameters.AddWithValue(string.Format("@{0}", arguments[i]), values[i]);
                        notEmpty = true;
                    }

                }

                if (notEmpty)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            cmd.Dispose();
            conn.Close();
        }
    }
}
