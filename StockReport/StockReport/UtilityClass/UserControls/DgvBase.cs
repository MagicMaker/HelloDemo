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
        public DgvBase()
        {
            InitializeComponent();
        }
        
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvBaseEx
            // 
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.BackgroundColor = Color.White;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        //private bool isSelected = false;
        //// 首列是否选择列
        //public bool IsSelected
        //{
        //    get { return isSelected; }
        //    set { isSelected = value; }
        //}

        // 绘制行号
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), this.RowHeadersDefaultCellStyle.Font, new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, this.RowHeadersWidth - 4, e.RowBounds.Height), this.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
