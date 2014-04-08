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
    public partial class FrmCustom : FormBase
    {
        // 此功能未用 采用实时效果
        //private bool isChanged = false;
        //// 是否有更改
        //public bool IsChanged
        //{
        //    get { return isChanged; }
        //    set
        //    {
        //        if (IsChanged != value)
        //        {
        //            isChanged = value;
        //            btnSave.Enabled = value;
        //        }
        //    }
        //}

        // 改动此控件 使之改动到父窗体
        private RibbonControl rc;
        // 记录选中控件
        //private ButtonItem btnLSelect = null;
        //private ButtonItem btnRSelect = null;

        public FrmCustom(RibbonControl ribbon)
        {
            InitializeComponent();
            this.Text = "自定义常用功能";

            listRight.DisplayMember = "Text";
            listRight.ValueMember = "Name";
            listRight.MeasureItem += (o, v) => v.ItemHeight = 20;

            rc = ribbon;
            treeLeft.BeginUpdate();
            foreach (BaseItem bi in rc.Items)
            {
                RibbonTabItem rti = bi as RibbonTabItem;
                if (rti != null)
                {
                    RibbonBar rbb = rti.Panel.Controls[0] as RibbonBar;
                    if (rti.Text == "常用功能")
                    {
                        foreach (BaseItem bs in rbb.Items)
                        {
                            Label lb = new Label();
                            lb.Name = bs.Name.Replace("tsb2", "tsb4");
                            lb.Text = bs.Text;
                            // 发现此事件不会被触发 所以不要
                            //lb.DoubleClick += (o, v) => listRight.Items.Remove(lb);
                            listRight.Items.Add(lb);
                        }
                    }
                    else
                    {
                        TreeNode tn = new TreeNode(rti.Text);
                        foreach (BaseItem bs in rbb.Items)
                        {
                            TreeNode tnn = new TreeNode(bs.Text);
                            tnn.ImageIndex = 2;
                            tnn.SelectedImageIndex = 3;
                            tnn.Name = bs.Name.Replace("tsb1", "tsb3");
                            tn.Nodes.Add(tnn);
                        }

                        treeLeft.Nodes.Add(tn);
                    }
                }
            }
            treeLeft.EndUpdate();
            treeLeft.NodeMouseDoubleClick += (o, v) => btnAdd.PerformClick();

            //{
            //    代码重复
            //    if (v.Node.Level > 0)
            //    {
            //        Label lb = new Label();
            //        lb.Name = v.Node.Name.Replace("tsb2", "tsb3");
            //        lb.Text = v.Node.Text;
            //        // 发现此事件不会被触发 所以不要
            //        //lb.DoubleClick += (s, r) => listRight.Items.Remove(lb);
            //        listRight.Items.Add(lb);
            //    }
            //};

            // 拖放操作 暂未实现

            // 此代码因为刷新问题而停用
            //  当然 也考虑性能问题，增加的全是 ButtonItem 控件
            //foreach (BaseItem bi in rc.Items)
            //{
            //    RibbonTabItem rti = bi as RibbonTabItem;
            //    if (rti != null)
            //    {
            //        RibbonBar rbb = rti.Panel.Controls[0] as RibbonBar;
            //        if (rti.Text == "常用功能")
            //        {
            //            foreach (BaseItem bs in rbb.Items)
            //            {
            //                ButtonItem btn = new ButtonItem(bs.Name.Replace("tsb1", "tsb3"));
            //                btn.AutoCheckOnClick = true;
            //                btn.Text = bs.Text;
            //                btn.Click += (o, v) =>
            //                {
            //                    if (btnRSelect != null)
            //                        btnRSelect.Checked = false;
            //                    btnRSelect = btn;
            //                };
            //                btn.DoubleClick += (o, v) =>
            //                    {
            //                        itemRight.Items.Remove(btn);
            //                        //itemRight.Refresh();
            //                    };
            //                itemRight.Items.Add(btn);
            //            }
            //        }
            //        else
            //        {
            //            foreach (BaseItem bs in rbb.Items)
            //            {
            //                // 此处错误是因为一个控件被多次添加
            //                //qatCustomizePanel1.itemPanelCommands.Items.Add(bs);
            //                ButtonItem btn = new ButtonItem(bs.Name.Replace("tsb1", "tsb2"));
            //                btn.AutoCheckOnClick = true;
            //                btn.Text = bs.Text;
            //                btn.Click += (o, v) =>
            //                    {
            //                        if (btnLSelect != null)
            //                            btnLSelect.Checked = false;
            //                        btnLSelect = btn;
            //                    };
            //                btn.DoubleClick += (o, v) =>
            //                    {
            //                        string strRight = btn.Name.Replace("tsb2", "tsb3");
            //                        if (!itemRight.Items.Contains(strRight))
            //                        {
            //                            ButtonItem btnRight = new ButtonItem(strRight);
            //                            btnRight.AutoCheckOnClick = true;
            //                            btnRight.Text = btn.Text;
            //                            btnRight.Click += (s, r) =>
            //                            {
            //                                if (btnRSelect != null)
            //                                    btnRSelect.Checked = false;
            //                                btnRSelect = btnRight;
            //                            };
            //                            btnRight.DoubleClick += (s, r) =>
            //                            {
            //                                itemRight.Items.Remove(btnRight);
            //                            };
            //                            itemRight.Items.Add(btnRight);
            //                            //itemRight.Refresh();
            //                        }
            //                    };
            //                //btn.Click += (o, v) => qatCustomizePanel1.buttonAddToQat.PerformClick();
            //                //btn.Click += (o, v) => FormMain.Instance.TabAdd(o, "Frm" + bs.Name.Replace("tsb1", ""));
            //                itemLeft.Items.Add(btn);
            //            }
            //            BaseItem bx = new ButtonItem();
            //            bx.Text = "--------------";
            //            itemLeft.Items.Add(bx);
            //        }
            //    }
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeLeft.SelectedNode != null && treeLeft.SelectedNode.Level > 0)
            {
                TreeNode tn = treeLeft.SelectedNode;

                foreach (object item in listRight.Items)
                {
                    if ((item as Label).Name == tn.Name.Replace("tsb3", "tsb4"))
                        return;
                }

                // 被上面代码取代
                //bool isContains = false;
                //foreach (object item in listRight.Items)
                //{
                //    if ((item as Label).Name == tn.Name.Replace("tsb2", "tsb3"))
                //    {
                //        isContains = true;
                //        break;
                //    }
                //}
                //if (isContains)
                //    return;

                Label lb = new Label();
                lb.Text = tn.Text;
                lb.Name = tn.Name;
                listRight.Items.Add(lb);

                FormMain.Instance.rtiAdd(tn.Name);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            for (int i = listRight.Items.Count - 1; i >= 0; i--)
            {
                if (listRight.SelectedItems.Contains(listRight.Items[i]))
                {
                    //#warning 此处很容易出问题 暂时解决方案
                    ((rc.Items["rti1Frequently"] as RibbonTabItem).Panel.Controls["ribbonBarCustom"] as RibbonBar).Items.Remove("tsb2" + (listRight.Items[i] as Label).Name.Substring(4));

                    listRight.Items.Remove(listRight.Items[i]);
                }
            }

            // 此处报错 修改集合时不能用 foreach
            //foreach (object item in listRight.SelectedItems)
            //{
            //    listRight.Items.Remove(item);
            //}
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            // 获取选中的第一行
            int minIndex = listRight.Items.Count;
            int maxIndex = 0;
            foreach (int item in listRight.SelectedIndices)
            {
                if (minIndex > item)
                    minIndex = item;
                if (maxIndex < item)
                    maxIndex = item;
            }
            if (minIndex == listRight.Items.Count || minIndex == 0)
                return;

            object temp = listRight.Items[minIndex - 1];
            listRight.Items.Remove(temp);
            listRight.Items.Insert(maxIndex, temp);

            //#warning 此处很容易出问题 暂时解决方案
            ((rc.Items["rti1Frequently"] as RibbonTabItem).Panel.Controls["ribbonBarCustom"] as RibbonBar).Items.Remove("tsb2" + (temp as Label).Name.Substring(4));
            FormMain.Instance.rtiAdd(maxIndex, (temp as Label).Name);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            // 获取选中的第一行
            int minIndex = listRight.Items.Count;
            int maxIndex = -1;
            foreach (int item in listRight.SelectedIndices)
            {
                if (minIndex > item)
                    minIndex = item;
                if (maxIndex < item)
                    maxIndex = item;
            }
            if (maxIndex == listRight.Items.Count - 1 || maxIndex == -1)
                return;

            object temp = listRight.Items[maxIndex + 1];
            listRight.Items.Remove(temp);
            listRight.Items.Insert(minIndex, temp);

            //#warning 此处很容易出问题 暂时解决方案
            ((rc.Items["rti1Frequently"] as RibbonTabItem).Panel.Controls["ribbonBarCustom"] as RibbonBar).Items.Remove("tsb2" + (temp as Label).Name.Substring(4));
            FormMain.Instance.rtiAdd(minIndex, (temp as Label).Name);
        }

        // 此功能未用 采用实时效果
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (itemRight.Items.Count > 0)
        //    {
        //        foreach (BaseItem item in itemRight.Items)
        //        {
        //        }
        //    }
        //    IsChanged = false;
        //}
    }
}
