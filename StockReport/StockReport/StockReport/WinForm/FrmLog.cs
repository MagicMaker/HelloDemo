using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockReport.WinForm
{
    public partial class FrmSysLog : FormBase
    {
        public FrmSysLog()
        {
            InitializeComponent();
            //this.Text = "系统日志";
            this.comboList1.AddRange("A,一", "B,二");
            this.comboList2.AddRange("C,三", "D,四");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            UtilityClass.PublicClass.Show(this, "OK");
        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            dgvBase1.DataBind(UtilityClass.SQLiteHelper.DB_Select("select * from jobs"));
        }
    }
}
