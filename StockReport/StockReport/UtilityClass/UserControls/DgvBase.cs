using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using System.Drawing;
using System.Data;

namespace UtilityClass
{
    public class DgvBase : DataGridViewX
    {
        // 首列是否选择列
        public string IsSelected { get; set; }

        // 绘制行号
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), this.RowHeadersDefaultCellStyle.Font, new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, this.RowHeadersWidth - 4, e.RowBounds.Height), this.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        public void DataBind(DataTable dt)
        {
            this.BackgroundColor = Color.Black;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (!dt.Columns.Contains("IsSelected"))
            {
                DataColumn dc = dt.Columns.Add("IsSelected", typeof(bool));
                dc.SetOrdinal(0);
            }

            this.DataSource = dt;
            this.Columns["IsSelected"].HeaderText = "";
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            base.OnCellClick(e);
            // 设置此列在点击时可改变值
            if (e.ColumnIndex > -1)
            {
                DataGridViewColumn dc = this.Columns[e.ColumnIndex];
                if (dc.ReadOnly && e.RowIndex > -1 && dc.Name == "IsSelected")
                    this[e.ColumnIndex, e.RowIndex].Value = !PublicClass.ToBoolean(this[e.ColumnIndex, e.RowIndex].Value);
            }
        }
    }
}
