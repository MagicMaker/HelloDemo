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
    public partial class FrmEmployee : FormBase
    {
        public FrmEmployee()
        {
            InitializeComponent();
            //this.Text = "员工信息";
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable dt = UtilityClass.SqlHelper.DB_Select("select * from jobs");
            dgvBase1.DataBind(dt);
        }
    }
}
