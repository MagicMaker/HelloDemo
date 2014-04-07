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
        internal static readonly string path = Application.StartupPath + "\\Login.ini";

        public FormBooks()
        {
            InitializeComponent();
            //this.Text = "帐套管理";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            throw new Exception("");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    contextMenuStrip1.Show(button1, button1.Width / 2, button1.Height / 2);
        //}
    }
}
