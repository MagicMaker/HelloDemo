using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;

namespace UtilityClass
{
    /// <summary>
    /// 一个不能修改的下拉框
    /// </summary>
    public class ComboList : ButtonX
    {
        /// <summary>
        /// 添加多个下拉项到按钮下
        /// </summary>
        /// <param name="text">"字段英文A,字段中文A","字段英文B,字段中文B"...</param>
        public void AddRange(params string[] text)
        {
            if (text != null)
            {
                this.SubItems.Clear();
                foreach (string item in text)
                {
                    string[] temp = item.Split(',');
                    if (temp.Length > 1)
                    {
                        ButtonItem bi = new ButtonItem();
                        bi.Tag = temp[0];
                        bi.Text = temp[1];
                        bi.Click += (o, v) =>
                            {
                                this.Tag = bi.Tag;
                                this.Text = bi.Text;
                            };
                        this.SubItems.Add(bi);
                    }
                }
                this.AutoExpandOnClick = true;
                if (this.SubItems.Count > 0)
                {
                    this.Tag = this.SubItems[0].Tag;
                    this.Text = this.SubItems[0].Text;
                }
            }
        }

    }
}
