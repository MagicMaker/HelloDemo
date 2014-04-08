using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace StockReport
{
    public partial class FrmCustomes : FormBase
    {
        private bool IsChanged = false;

        public FrmCustomes(SubItemsCollection items)
        {
            InitializeComponent();
            this.Text = "自定义常用功能";

            //qatCustomizePanel1.labelCategories.Text = "添加菜单到常用项：";
            //qatCustomizePanel1.labelCategories.ForeColor = Color.FromArgb(21, 66, 139);
            //qatCustomizePanel1.checkQatBelowRibbon.Text = "BCD";
            qatCustomizePanel1.labelCategories.Visible = false;
            qatCustomizePanel1.checkQatBelowRibbon.Visible = false;
            qatCustomizePanel1.buttonAddToQat.Text = ">>";
            qatCustomizePanel1.buttonRemoveFromQat.Text = "<<";

            // 左侧栏子菜单从上边菜单里得来
            foreach (BaseItem bi in items)
            {
                RibbonTabItem rti = bi as RibbonTabItem;
                if (rti != null)
                {
                    RibbonBar rbb = rti.Panel.Controls[0] as RibbonBar;
                    if (rti.Text == "常用功能")
                    {
                        foreach (BaseItem bs in rbb.Items)
                        {
                            ButtonItem btn = new ButtonItem(bs.Name.Replace("tsb1", "tsb2"));
                            btn.AutoCheckOnClick = true;
                            btn.Text = bs.Text;
                            qatCustomizePanel1.itemPanelQat.Items.Add(btn);
                        }
                    }
                    else
                    {
                        foreach (BaseItem bs in rbb.Items)
                        {
                            // 此处错误是因为一个控件被多次添加
                            //qatCustomizePanel1.itemPanelCommands.Items.Add(bs);
                            ButtonItem btn = new ButtonItem(bs.Name.Replace("tsb1", "tsb2"));
                            btn.AutoCheckOnClick = true;
                            btn.Text = bs.Text;
                            //btn.Click += (o, v) => qatCustomizePanel1.buttonAddToQat.PerformClick();
                            //btn.Click += (o, v) => FormMain.Instance.TabAdd(o, "Frm" + bs.Name.Replace("tsb1", ""));
                            qatCustomizePanel1.itemPanelCommands.Items.Add(btn);
                        }
                        BaseItem bx = new ButtonItem();
                        bx.Text = "--------------";
                        qatCustomizePanel1.itemPanelCommands.Items.Add(bx);
                    }
                }
            }
        }

        private void FrmCustom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UtilityClass.PublicClass.MsgBox(this, "是否保存并应用更改？"))
            {
                // 执行保存动作
                // Do somethings...
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 执行保存动作
            // Do somethings...
            IsChanged = false;
        }
    }
}
