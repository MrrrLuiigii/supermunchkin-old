using System.Collections.Generic;

namespace Database
{
    public class CRUD
    {
        Database database = new Database();

        private string GetReadQuery(string table, string[] arguments)
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

        public List<string> Read(string table, string[] arguments)
        {
            string sql = GetReadQuery(table, arguments);
            return database.Read(arguments, sql);
        }

        public List<string> ReadWhere(string table, string[] arguments, string[] where)
        {
            string sql = GetReadQuery(table, arguments) + " where ";

            for (int i = 0; i < where.Length; i++)
            {
                sql += string.Format("{0}", where[i]);

                if (i + 1 < where.Length)
                {
                    sql += string.Format(" and ");
                }
            }

            return database.Read(arguments, sql);
        }

        public void Write(string table, string[] arguments, string[] values)
        {
            string sql = string.Format("insert into {0} (", table);
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
            database.Write(table, arguments, values, sql);
        }
    }
}
