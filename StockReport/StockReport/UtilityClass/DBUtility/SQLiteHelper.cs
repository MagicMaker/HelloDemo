using System;
using System.Data;
using System.Data.SQLite;

namespace UtilityClass
{
    /// 2014年3月31日22时00分49秒 6
    /// <summary>
    /// The SQLiteHelper class is intended to encapsulate high performance, 
    /// scalable best practices for common uses of SQLiteClient.
    /// </summary>
    public abstract class SQLiteHelper
    {
        //Database connection strings
        public static string connStr; //= "data source=" + FormLogin.FilePath + ";password=stockxyz";

        /// <summary>
        /// 执行查询一个 SQLite 语句，返回影响的行数。
        /// </summary>
        /// <param name="cmdText">SQLite 语句</param>
        /// <param name="cmdParameters">SQLite 参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, params SQLiteParameter[] cmdParameters)
        {
            return ExecuteNonQuery(cmdText, CommandType.Text, cmdParameters);
        }

        /// <summary>
        /// 执行查询一个 SQLite 语句，返回影响的行数。
        /// </summary>
        /// <param name="cmdText">SQLite 语句</param>
        /// <param name="type">语句类型 默认为 Text</param>
        /// <param name="cmdParameters">SQLite 参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string cmdText, CommandType type, params SQLiteParameter[] cmdParameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.QuickOpen();
                SQLiteCommand cmd = BuildQueryCommand(conn, cmdText, type, cmdParameters);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行一个查询，返回一个object
        /// </summary>
        /// <param name="cmdText">SQLite 语句</param>
        /// <param name="cmdParameters">SQLite 参数</param>
        /// <returns>第一行第一列的值</returns>
        public static object ExecuteScalar(string cmdText, params SQLiteParameter[] cmdParameters)
        {
            return ExecuteScalar(cmdText, CommandType.Text, cmdParameters);
        }

        /// <summary>
        /// 执行一个查询，返回一个object
        /// </summary>
        /// <param name="cmdText">SQLite 语句</param>
        /// <param name="type">语句类型 默认为 Text</param>
        /// <param name="cmdParameters">SQLite 参数</param>
        /// <returns>第一行第一列的值</returns>
        public static object ExecuteScalar(string cmdText, CommandType type, params SQLiteParameter[] cmdParameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.QuickOpen();
                SQLiteCommand cmd = BuildQueryCommand(conn, cmdText, type, cmdParameters);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 执行一个查询，返回一个DataTable 数据集
        /// </summary>
        /// <param name="cmdText">SQLite 语句</param>
        /// <param name="parameters">SQLite 参数</param>
        /// <returns>DataTable 的结果集</returns>
        public static DataTable DB_Select(string cmdText, params SQLiteParameter[] cmdParameters)
        {
            return DB_Select(cmdText, CommandType.Text, cmdParameters);
        }

        /// <summary>
        /// 执行一个查询，返回一个DataTable 数据集
        /// </summary>
        /// <param name="cmdText">SQLite 语句</param>
        /// <param name="type">语句类型 默认为 Text</param>
        /// <param name="parameters">SQLite 参数</param>
        /// <returns>DataTable 的结果集</returns>
        public static DataTable DB_Select(string cmdText, CommandType type, params SQLiteParameter[] cmdParameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.QuickOpen();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter())
                {
                    da.SelectCommand = BuildQueryCommand(conn, cmdText, type, cmdParameters);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, string tableName, params SQLiteParameter[] cmdParameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                conn.QuickOpen();
                using (SQLiteDataAdapter da = new SQLiteDataAdapter())
                {
                    da.SelectCommand = BuildQueryCommand(conn, storedProcName, CommandType.StoredProcedure, cmdParameters);
                    DataSet ds = new DataSet();
                    da.Fill(ds, tableName);
                    return ds;
                }
            }
        }

        /// <summary>
        /// 构建 SQLiteCommand 对象
        /// </summary>
        /// <param name="cmdText">SQLite 语句</param>
        /// <param name="cmdParameters">SQLite 参数</param>
        /// <returns>SQLiteCommand</returns>
        private static SQLiteCommand BuildQueryCommand(SQLiteConnection conn, string cmdText, params SQLiteParameter[] cmdParameters)
        {
            return BuildQueryCommand(conn, cmdText, CommandType.Text, cmdParameters);
        }

        /// <summary>
        /// 构建 SQLiteCommand 对象
        /// </summary>
        /// <param name="cmdText">SQLite 语句</param>
        /// <param name="type">语句类型 默认为 Text</param>
        /// <param name="cmdParameters">SQLite 参数</param>
        /// <returns>SQLiteCommand</returns>
        private static SQLiteCommand BuildQueryCommand(SQLiteConnection conn, string cmdText, CommandType type, params SQLiteParameter[] cmdParameters)
        {
            SQLiteCommand command = new SQLiteCommand(cmdText, conn);
            command.CommandType = type;
            foreach (SQLiteParameter parameter in cmdParameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }
    }
}

