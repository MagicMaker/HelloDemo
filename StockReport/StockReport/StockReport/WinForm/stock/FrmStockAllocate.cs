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
    public partial class FrmStockAllocate : FormBase
    {
        public FrmStockAllocate()
        {
            InitializeComponent();
            //this.Text = "库存调拨";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = UtilityClass.SqlHelper.DB_Select("select * from jobs");
            dgvBaseEx1.DataBind(dt);
        }
    }
}
