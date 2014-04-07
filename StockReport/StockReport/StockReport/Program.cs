using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using UtilityClass;
using System.Threading;

namespace StockReport
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //// 开始监听 // 已使用配置文件初始化
            //Trace.Listeners.Clear();
            //Trace.Listeners.Add(new MyTraceListener());

            ApplicationEventHandlerClass AppEvents = new ApplicationEventHandlerClass();
            Application.ThreadException += new ThreadExceptionEventHandler(AppEvents.OnThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (new FormBooks().ShowDialog() == DialogResult.OK)
                Application.Run(FormMain.Instance);
        }
    }

    public class ApplicationEventHandlerClass
    {
        public void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //[Conditional("DEBUG")]
            Trace.TraceError("A");
            Trace.TraceWarning("B");
            Trace.TraceInformation("C");
            Trace.WriteLine("ABC");
            Trace.Flush();  // 开始输出
            //System.IO.File.AppendAllText(Application.StartupPath + "\\Error.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\t" + e.Exception.Message + "\r\n\r\n");
            PublicClass.ShowErr(null, "程序出现错误：\r\n" + e.Exception.Message + "\r\n\r\n如有必要，请联系产品供应商以解决此问题！");
        }
    }
}
