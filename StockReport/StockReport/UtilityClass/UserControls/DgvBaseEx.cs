using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;

namespace UtilityClass
{
    public class DgvBaseEx : DgvBase
    {
        private const string IsSelected = "IsSelected";
        private CheckBox chk = null;
        // CheckBox.Checked 有点不稳定

        [Browsable(false)]
        //[Category("Behavior")]
        [DefaultValue(false)]
        //[Description("获取控件是否包含名为 IsSelected 的可选列。")]
        /// <summary>
        /// 获取控件是否包含名为 IsSelected 的可选列。
        /// </summary>
        public bool ContainsSelectColumn { get; private set; }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            if (ContainsSelectColumn && chk == null)
            {
                //Debug.WriteLine("OnColumnAdded");
                chk = new CheckBox();
                chk.Size = new Size(14, 14);
                chk.Click += new EventHandler(chk_Click);
                this.Controls.Add(chk);
            }

            //if (!Initialize)
            //{
            //    if (this.Columns.Contains(IsSelected))
            //    {
            //        Debug.WriteLine("OnColumnAdded");
            //        if (chk == null)
            //        {
            //            chk = new CheckBox();
            //            chk.Size = new Size(14, 14);
            //            this.Controls.Add(chk);
            //            chk.Click += (o, v) =>
            //            {
            //                DataTable dt = this.DataSource as DataTable;
            //                if (dt != null)
            //                    foreach (DataRow dr in dt.Rows)
            //                    {
            //                        dr[IsSelected] = chk.Checked;
            //                    }
            //            };
            //        }
            //        //Rectangle rc = this.GetCellDisplayRectangle(Columns[IsSelected].Index, -1, true);
            //        Rectangle rc = this.GetCellDisplayRectangle(0, -1, true);
            //        if (rc.Width > 17)
            //        {
            //            chk.Left = rc.Left + (rc.Width - chk.Width) / 2;
            //            chk.Top = rc.Top + (rc.Height - chk.Height) / 2;
            //            if (!chk.Visible) chk.Visible = true;
            //        }
            //        else
            //            chk.Visible = false;
            //        Initialize = true;
            //    }
            //}
            base.OnColumnAdded(e);
        }

        private void chk_Click(object sender, EventArgs e)
        {
            DataTable dt = this.DataSource as DataTable;
            if (dt != null)
                foreach (DataRow dr in dt.Rows)
                    dr[IsSelected] = chk.Checked;
        }

        /// <summary>
        /// 公用方法 采用此方法绑定后的数据集第一列可选
        /// </summary>
        /// <param name="dt"></param>
        public void DataBind(DataTable dt)
        {
            ContainsSelectColumn = true;

            if (dt.Columns.Contains(IsSelected))
                throw new Exception("添加列时出现错误！\r\n\r\n已存在 Name 为 " + IsSelected + " 的列！");

            DataColumn dc = dt.Columns.Add(IsSelected, typeof(bool));
            dc.SetOrdinal(0);

            this.DataSource = dt;
            this.Columns[0].Frozen = true;
            this.Columns[0].HeaderText = "";
            this.Columns[0].ReadOnly = true;
            this.Columns[0].Width = 23;
            //this.Columns[IsSelected].HeaderText = "";
            //this.Columns[IsSelected].ReadOnly = true;
            //this.Columns[IsSelected].Width = 23;
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            // 设置此列在点击时可改变值
            //if (e.ColumnIndex > -1)
            //{
            //    DataGridViewColumn dc = this.Columns[e.ColumnIndex];
            //    if (dc.ReadOnly && e.RowIndex > -1 && dc.Name == IsSelected)
            //        this[e.ColumnIndex, e.RowIndex].Value = !PublicClass.ToBoolean(this[e.ColumnIndex, e.RowIndex].Value);
            //}
            if (chk != null && e.ColumnIndex == 0)
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewColumn dc = this.Columns[0];
                    if (dc.ReadOnly)
                        this[0, e.RowIndex].Value = !PublicClass.ToBoolean(this[0, e.RowIndex].Value);
                }
                else
                {
                    chk.Checked = !chk.Checked;
                    chk_Click(null, null);
                }
            }
            else
                base.OnCellClick(e);
        }

        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            if (e.Column.Name == IsSelected)
            {
                //Debug.WriteLine("OnColumnWidthChanged");
                Rectangle rc = this.GetCellDisplayRectangle(Columns[IsSelected].Index, -1, true);
                if (rc.Width > 17)
                {
                    chk.Left = rc.Left + (rc.Width - chk.Width) / 2;
                    chk.Top = rc.Top + (rc.Height - chk.Height) / 2;
                    if (!chk.Visible) chk.Visible = true;
                }
                else
                    chk.Visible = false;
            }
            base.OnColumnWidthChanged(e);
        }

        //protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        //{
        //    //if (this.Columns.Contains(IsSelected) && e.ColumnIndex ==-1)
        //    //if (ContainsSelectColumn && e.ColumnIndex == 0 && e.RowIndex == -1)
        //    //{
        //    //    Debug.WriteLine("OnCellPainting");
        //    //    if (chk == null)
        //    //    {
        //    //        chk = new CheckBox();
        //    //        chk.Size = new Size(14, 14);
        //    //        this.Controls.Add(chk);
        //    //        chk.Click += (o, v) =>
        //    //        {
        //    //            DataTable dt = this.DataSource as DataTable;
        //    //            if (dt != null)
        //    //                foreach (DataRow dr in dt.Rows)
        //    //                {
        //    //                    dr[IsSelected] = chk.Checked;
        //    //                }
        //    //        };
        //    //    }

        //    //if (chk != null && e.RowIndex ==-1 && e.ColumnIndex == 0)
        //    //{
        //    //    Debug.WriteLine("OnCellPainting");
        //    //    Rectangle rc = this.GetCellDisplayRectangle(Columns[IsSelected].Index, -1, true);
        //    //    if (rc.Width > 17)
        //    //    {
        //    //        chk.Left = rc.Left + (rc.Width - chk.Width) / 2;
        //    //        chk.Top = rc.Top + (rc.Height - chk.Height) / 2;
        //    //        if (!chk.Visible) chk.Visible = true;
        //    //    }
        //    //    else
        //    //        chk.Visible = false;
        //    //    Initialize = true;
        //    //}
        //    base.OnCellPainting(e);
        //}
    }
}
