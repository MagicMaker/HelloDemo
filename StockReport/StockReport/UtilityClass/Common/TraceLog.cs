using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace UtilityClass
{
    public class MyTraceListener : TraceListener
    {
        // 初始化时给定一个日志文件位置
        public string FilePath { get; private set; }

        public MyTraceListener(string filepath)
        {
            FilePath = filepath;
        }

        /// <summary>
        /// 保存 错误信息 到指定日志
        ///  此方法已重写 实际效果同 WriteLine
        /// </summary>
        public override void Write(string message)
        {
            File.AppendAllText(FilePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + message + Environment.NewLine);
        }

        /// <summary>
        /// 保存 错误信息 到指定日志
        /// </summary>
        public override void WriteLine(string message)
        {
            File.AppendAllText(FilePath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine + message + Environment.NewLine);
        }

        /// <summary>
        /// 输入一个 Exception 对象
        ///  它将在日志文件中保存 错误信息 和 堆栈信息
        /// </summary>
        public override void WriteLine(object o)
        {
            string msg = "";
            if (o is Exception)
            {
                Exception ex = (Exception)o;
                msg = ex.Message + Environment.NewLine;
                msg += ex.StackTrace;
            }
            else if (o != null)
            {
                msg = o.ToString();
            }
            WriteLine(msg);
        }

        /// <summary>
        /// 输入一个 错误信息 和一个 分类名称
        ///  它将在日志文件中保存 错误信息
        /// </summary>
        public override void WriteLine(string message, string category)
        {
            string msg = "";
            if (string.IsNullOrWhiteSpace(category) == false)  // category 参数不为空
            {
                msg = category + ":";
            }
            msg += message;
            WriteLine(msg);
        }

        /// <summary>
        /// 输入一个 Exception 对象和一个 分类名称
        ///  它将在日志文件中保存 错误信息 和 堆栈信息
        /// </summary>
        public override void WriteLine(object o, string category)
        {
            string msg = "";
            if (string.IsNullOrWhiteSpace(category) == false)  // category 参数不为空
            {
                msg = category + ":";
            }
            if (o is Exception)
            {
                var ex = (Exception)o;
                msg += ex.Message + Environment.NewLine;
                msg += ex.StackTrace;
            }
            else if (o != null)
            {
                msg = o.ToString();
            }
            WriteLine(msg);
        }
    }
}
