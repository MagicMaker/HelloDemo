using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace DBUtility
{
    public class MyTraceListener : TraceListener
    {
        public string FilePath { get; private set; }

        public MyTraceListener(string filepath)
        {
            FilePath = filepath;
        }

        public override void Write(string message)
        {
            //throw new NotImplementedException();
            File.AppendAllText("D:\\1.log", message);
        }

        public override void WriteLine(string message)
        {
            //throw new NotImplementedException();
            File.AppendAllText("d:\\1.log", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss    ") + message + Environment.NewLine);
        }

        /// <summary>
        /// 输入一个异常
        /// </summary>
        /// <param name="o">可接 Exception ex 的 ex 对象</param>
        /// <param name="category">分类</param>
        public override void Write(object o, string category)
        {
            //base.Write(o, category);
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
