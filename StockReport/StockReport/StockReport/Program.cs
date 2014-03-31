using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            ApplicationEventHandlerClass AppEvents = new ApplicationEventHandlerClass();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(AppEvents.OnThreadException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin fr = new FormLogin();
            if (fr.ShowDialog() == DialogResult.OK)
                Application.Run(FormMain.Instance);
        }
    }

    public class ApplicationEventHandlerClass
    {
        public void OnThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            System.IO.File.AppendAllText(Application.StartupPath + "\\Error.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "\t" + e.Exception.Message + "\r\n\r\n");
            PublicClass.ShowErr(null, "程序出现错误：\r\n" + e.Exception.Message + "\r\n\r\n如有必要，请联系产品供应商以解决此问题！");
        }
    }
}
