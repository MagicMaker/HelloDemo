using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace UtilityClass
{
    /// <summary>
    /// 此代码未用
    /// </summary>
    public class ListBoxEx : ListBox
    {
        // 重写高度 失败 代码效果不咋地

        public ListBoxEx()
        {
            // 允许拖放
            //this.AllowDrop = true;

            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (!this.DesignMode)
            {
                int rowIndex = e.Index;
                Graphics g = e.Graphics;
                Rectangle rc = e.Bounds;
                string text;
                Label lb = this.Items[rowIndex] as Label;
                if (lb != null)
                    text = lb.Text;
                else
                    text = this.Items[rowIndex].ToString();
                //if((e.State & DrawItemState.Selected )== DrawItemState.Selected )
                if (e.State == DrawItemState.Selected)
                {
                    g.DrawRectangle(Pens.Blue, rc.Left, rc.Top, rc.Width - 1, rc.Height - 1);
                    Rectangle rect = new Rectangle(rc.Left - 2, rc.Top - 2, rc.Width - 4, rc.Height - 4);
                    g.FillRectangle(Brushes.Blue, rect);
                    TextRenderer.DrawText(g, text, this.Font, rect, Color.White, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                }
                else
                {
                    g.FillRectangle(Brushes.White, rc);
                    TextRenderer.DrawText(g, text, this.Font, rc, Color.Black, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
                }
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
            e.ItemHeight = 20;
        }

        // 添加拖放操作 功能没做好，屏蔽
        //protected override void OnDragEnter(DragEventArgs drgevent)
        //{
        //    base.OnDragEnter(drgevent);
        //    if (drgevent.Data.GetType() == this.SelectedItem.GetType())
        //        drgevent.Effect = DragDropEffects.Move;
        //    else
        //        drgevent.Effect = DragDropEffects.None;
        //}

        //protected override void OnDragDrop(DragEventArgs drgevent)
        //{
        //    base.OnDragDrop(drgevent);
        //    this.Items.Remove(this.SelectedItem);
        //    this.Items.Insert(0, this.SelectedItem);
        //}

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    if (e.Button == System.Windows.Forms.MouseButtons.Left)
        //    {
        //        this.DoDragDrop(this.SelectedItem, DragDropEffects.Move);
        //    }
        //}
    }
}
