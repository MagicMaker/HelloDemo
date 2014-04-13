using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StockReport
{
    public partial class FrmChangePwd : FormBaseDialog
    {
        public FrmChangePwd()
        {
            InitializeComponent();
            //this.Text = "修改密码";
        }

        private void FrmChangePwd_Load(object sender, EventArgs e)
        {
            //if (FormMain.user != null)
            //    txtUserName.Text = FormMain.user.username;
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtPwd1.Focus();
        }

        private void txtPwd1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                txtPwd2.Focus();
        }

        private void txtPwd2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnOK.PerformClick();
        }

        private void txtPwd2_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPwd1.Text == txtPwd.Text)
            {
                errorProvider1.SetError(txtPwd1, "原密码与新密码不能相同！");
                txtPwd1.Focus();
                return;
            }
            if (txtPwd1.Text != txtPwd2.Text)
            {
                errorProvider1.SetError(txtPwd2, "两次输入的密码不一致！");
                txtPwd2.Focus();
                return;
            }
            //if (FormMain.user.userpwd == Generic.MD5(txtPwd.Text))
            //{
            //    string strtemp = Generic.MD5(txtPwd2.Text);
            //    if (SqlHelper.ExecuteNonQuery("update trd_UserInfo set UserPwd='" + strtemp + "' where uID=@uID", new SqlParameter("@uID", FormMain.user.uid)) > 0)
            //    {
            //        FormMain.user.userpwd = strtemp;
            //        MessageBox.Show(this, "修改密码成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Generic.InsertLog(FormMain.user, "修改密码成功！", "用户");
            //        txtPwd.Clear();
            //        txtPwd1.Clear();
            //        txtPwd2.Clear();
            //        this.DialogResult = DialogResult.OK;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show(this, "密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtPwd.Focus();
            //}
        }
    }
}
