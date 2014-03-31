using System;
using System.Management;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data;
using System.Collections.Generic;
using System.Data.SQLite;

namespace StockReport
{
    /// <summary>
    /// 登录模块
    ///    2014年3月31日21时55分28秒 6 修改
    ///     修改内容： 仿QQ  最近成功登陆的用户 会出现在选框第一位。
    ///     
    /// </summary>
    public partial class FormLogin : Office2007Form
    {
        // 设置配置文件路径
        internal static readonly string path = Application.StartupPath + "\\Login.ini";
        /// <summary>
        /// 记录用户当前登录时的IP 地址,记录日志时用.
        /// </summary>
        private string userIP = "";

        private string[] UserId = PublicClass.ReadIni("Login", "User").Trim(',', '，').Split(',', '，');

        public FormLogin()
        {
            InitializeComponent();

            // 加载之前登录的用户
            comUserId.Items.Clear();
            comUserId.Items.AddRange(UserId);

            if (!System.IO.File.Exists(SQLiteHelper.connStr))
            {
                try
                {
                    SQLiteConnection.CreateFile(SQLiteHelper.connStr);
                    using (SQLiteConnection conn = new SQLiteConnection(SQLiteHelper.connStr))
                    {
                        SQLiteConnectionStringBuilder cb = new SQLiteConnectionStringBuilder();
                        cb.DataSource = SQLiteHelper.connStr;
                        cb.Password = "stockxyz";
                        conn.ConnectionString = cb.ToString();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            // 获取IP 地址
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection nics = mc.GetInstances();
                foreach (ManagementObject nic in nics)
                {
                    if (Convert.ToBoolean(nic["ipEnabled"]))
                    {
                        userIP = (nic["IPAddress"] as String[])[0];
                        break;
                    }
                }
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// 返回一个字符串,用于写入配置文件中
        /// </summary>
        private string GetStr()
        {
            List<string> temps = new List<string>(UserId);
            if (temps.Contains(comUserId.Text))
            {
                temps.Remove(comUserId.Text);
            }
            temps.Insert(0, comUserId.Text);
            string temp = "";
            foreach (string item in temps)
            {
                temp += item + ",";
            }
            return temp;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            comUserId.Text = comUserId.Text.Trim();
            if (PublicClass.IsNullOrEmpty(comUserId.Text))
            {
                comUserId.Focus();
                errorProvider1.SetError(comUserId, "用户名不能为空!");
                return;
            }
            // 验证登录
            string State;
            if (LoginValidate(comUserId.Text, txtUserPwd.Text, out State))
            {
                if (State == "1")
                    errorProvider1.SetError(comUserId, "该用户已停用");
                else
                {
                    PublicClass.WriteIni("Login", "User", GetStr());
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                if (PublicClass.IsNullOrEmpty(txtUserPwd.Text))
                    txtUserPwd.Focus();
                else
                {
                    errorProvider1.SetError(txtUserPwd, "用户名或密码错误!");
                }
            }
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        private bool LoginValidate(string UserName, string UserPwd, out string State)
        {
            DataTable dt = SQLiteHelper.DB_Select("select UserPwd,UserState from UserInfo where staffname=@UserName", new SQLiteParameter("@UserName", UserName));
            if (dt.Rows.Count > 0)
            {
                State = dt.Rows[0][1].ToString();
                return PublicClass.MD5(UserPwd) == dt.Rows[0][0].ToString();
            }
            State = "0";
            return false;
        }

        private void comUserId_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void labelX1_DoubleClick(object sender, EventArgs e)
        {
            comUserId.Text = PublicClass.EncryptDES(comUserId.Text);
        }

        private void comUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!PublicClass.IsNullOrEmpty(comUserId.Text))
                {
                    if (!PublicClass.IsNullOrEmpty(txtUserPwd.Text))
                        btnOK.PerformClick();
                    else
                        txtUserPwd.Focus();
                }
                else
                    errorProvider1.SetError(comUserId, "用户名不能为空!");
            }
        }

        private void txtUserPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnOK.PerformClick();
        }

        private void comUserId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comUserId.SelectedIndex > -1 && !PublicClass.IsNullOrEmpty(comUserId.Text))
            {
                txtUserPwd.Focus();
            }
        }
    }
}
