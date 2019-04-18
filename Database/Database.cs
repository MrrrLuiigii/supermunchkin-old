using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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

        public List<string> Read(string[] arguments, string sql)
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

        public void Write(string table, string[] arguments, string[] values, string sql)
        {
            bool notEmpty = false;

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
