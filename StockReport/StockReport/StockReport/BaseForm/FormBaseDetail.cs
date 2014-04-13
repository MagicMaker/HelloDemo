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
    public partial class FormBaseDetail : FormBase
    {
        public FormBaseDetail()
        {
            InitializeComponent();
            //this.Text = "此窗体将出现在 FormMain.tabControls1 里";
            //FormMain.Instance.ResizeEnd += (o, v) =>
            //    {
            //        // 本想做随窗体一起拉伸缩小的 后来发现不需要做这件事
            //    };
        }
    }
}
