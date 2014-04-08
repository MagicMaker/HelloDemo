using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SQLite;
using System.Threading;
using System.Diagnostics;

namespace UtilityClass
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class SQLExtensions
    {
        public static void QuickOpen(this SqlConnection conn)
        {
            int timeout = PublicClass.ToInt32(ConfigurationManager.AppSettings["TimeOut"]);
            string strError = "";
            timeout = Math.Max(Math.Min(30000, timeout), 3000);

            // We'll use a Stopwatch here for simplicity. A comparison to a stored DateTime.Now value could also be used
            Stopwatch sw = new Stopwatch();
            bool connectSuccess = false;

            // Try to open the connection, if anything goes wrong, make sure we set connectSuccess = false
            Thread t = new Thread(delegate()
            {
                sw.Start();
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
                connectSuccess = true;
            });

            // Make sure it's marked as a background thread so it'll get cleaned up automatically
            t.IsBackground = true;
            t.Start();

            // Keep trying to join the thread until we either succeed or the timeout value has been exceeded
            while (timeout > sw.ElapsedMilliseconds)
                if (t.Join(1))
                    break;

            // If we didn't connect successfully, throw an exception
            if (!string.IsNullOrEmpty(strError))
                throw new Exception(strError);
            if (!connectSuccess)
                throw new Exception("连接超时！\r\n未能连接到数据库！\r\n如有需要，可更改App.config 中的 TimeOut 值");
        }

        public static void QuickOpen(this SQLiteConnection conn)
        {
            int timeout = PublicClass.ToInt32(ConfigurationManager.AppSettings["TimeOut"]);
            string strError = "";
            timeout = Math.Max(Math.Min(30000, timeout), 3000);

            // We'll use a Stopwatch here for simplicity. A comparison to a stored DateTime.Now value could also be used
            Stopwatch sw = new Stopwatch();
            bool connectSuccess = false;

            // Try to open the connection, if anything goes wrong, make sure we set connectSuccess = false
            Thread t = new Thread(delegate()
            {
                sw.Start();
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
                connectSuccess = true;
            });

            // Make sure it's marked as a background thread so it'll get cleaned up automatically
            t.IsBackground = true;
            t.Start();

            // Keep trying to join the thread until we either succeed or the timeout value has been exceeded
            while (timeout > sw.ElapsedMilliseconds)
                if (t.Join(1))
                    break;

            // If we didn't connect successfully, throw an exception
            if (!string.IsNullOrEmpty(strError))
                throw new Exception(strError);
            if (!connectSuccess)
                throw new Exception("连接超时！\r\n未能连接到数据库！\r\n如有需要，可更改App.config 中的 TimeOut 值");
        }
    }
}
