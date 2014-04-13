using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockReport
{
    /// <summary>
    /// 帐套管理 － 系统登录
    /// </summary>
    public partial class FormBooks : FormBase
    {
        // 插入 个人设置 到 个性化配置文件
        internal static readonly string pathLogin = Application.StartupPath + "\\Login.ini";
        // 插入 错误日志 到 错误统计文件
        internal static readonly string pathError = Application.StartupPath + "\\Error.ini";

        public FormBooks()
        {
            InitializeComponent();
            //this.Text = "帐套管理";

            // 如果采用 SQLite 
            // 1. 获得连接字符串
            // 2. 看数据库是否为空 为空则需先建表
            string dbAdd = System.Configuration.ConfigurationManager.ConnectionStrings["SQLiteString"].ConnectionString;
            UtilityClass.SQLiteHelper.connStr = "DataBase=" + dbAdd + ";password=stockxyz";

            // 如果采用 MSSQL
            //  这里不需要初始化 当然 可以做初始化数据界面
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // 插入日志到数据库
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.highlighter1.SetHighlightColor(txtUserPwd, DevComponents.DotNetBar.Validator.eHighlightColor.Red);
            txtUserPwd.Focus();
        }
    }
}
