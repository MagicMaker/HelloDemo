using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace StockReport
{
    public partial class FormMain : FormBase
    {
        private static FormMain instance;
        private ButtonItem btnSelected = null;

        // 单例模式
        public static FormMain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FormMain();
                }
                return instance;
            }
        }

        private FormMain()
        {
            InitializeComponent();
            // 保证选中第一个选项卡
            if (ribbonControl1.Items.Count > 0 && ribbonControl1.Items[0] is RibbonTabItem)
                ribbonControl1.SelectedRibbonTabItem = (RibbonTabItem)ribbonControl1.Items[0];
            // 加载各种样式的菜单项
            foreach (string str in Enum.GetNames(typeof(eStyle)))
            {
                ButtonItem btn = new ButtonItem();
                btn.Text = str;
                btn.Click += (o, v) => styleManager1.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), (o as ButtonItem).Text);
                btnStyle.SubItems.Add(btn);
            }

            // 左侧栏子菜单从上边菜单里得来
            foreach (BaseItem bi in ribbonControl1.Items)
            {
                RibbonTabItem rti = bi as RibbonTabItem;
                if (rti != null && rti.Text != "常用功能")
                {
                    SideBarPanelItem sbp = new SideBarPanelItem();
                    sbp.FontBold = true;
                    sbp.Name = rti.Name.Replace("rti1", "sbp");
                    sbp.Text = rti.Text;

                    RibbonBar rbb = rti.Panel.Controls[0] as RibbonBar;
                    foreach (BaseItem bs in rbb.Items)
                    {
                        ButtonItem item = bs as ButtonItem;
                        ButtonItem btn = new ButtonItem();
                        btn.AutoCheckOnClick = true;
                        btn.ButtonStyle = eButtonStyle.ImageAndText;
                        btn.Click += new EventHandler(btn_Click);
                        btn.Image = item.Image;
                        btn.ImageFixedSize = new System.Drawing.Size(16, 16);
                        btn.Name = item.Name.Replace("tsb1", "btn");
                        btn.Text = item.Text;
                        sbp.SubItems.Add(btn);
                    }

                    this.sideBar1.Panels.Add(sbp);
                }
            }

            labLink.Click += (o, v) => Process.Start(labLink.Text);

            expandableSplitter1.Click += (o, v) => panel1.Visible = !panel1.Visible;
            // 这段代码不要去掉
            expandableSplitter1.HotBackColor = Color.FromArgb(227, 239, 255);
            expandableSplitter1.HotBackColor2 = Color.FromArgb(54, 107, 207);

            this.Text += " - [会计期间：" + "2013年9月]";

            labUser.Text = "当前用户：";

            string path = "帐套位置";
            btnPlace.Click += (o, v) => Process.Start("Explorer.exe", "/select," + path);
            btnPlace.Text = "[公司名称] " + path;

            labTime.Text = DateTime.Now.ToString("yyyy年M月d日 H:mm");
            // timer1.Interval = 10000; 每 10 秒刷新一次
            timer1.Tick += (o, v) => labTime.Text = DateTime.Now.ToString("yyyy年M月d日 H:mm");
            timer1.Start();
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            bool bl = ribbonControl1.Expanded;
            reflectionLabel1.Visible = !bl;
            ribbonControl1.Expanded = !bl;
            btnExpand.Image = bl ? global::StockReport.Properties.Resources.down : global::StockReport.Properties.Resources.up;
        }

        // 点左侧边栏里按钮时触发此事件
        //      此事件会试图调用主菜单上同名称点击事件
        private void btn_Click(object sender, EventArgs e)
        {
            ButtonItem btn = sender as ButtonItem;
            if (btn != null)
            {
                //  切换选中状态
                if (btnSelected != null)
                    btnSelected.Checked = false;
                btnSelected = btn;

                //  查找相应点击事件对应的方法
                string methodname = btn.Name.Replace("btn", "tsb1") + "_Click";
                try
                {
                    MethodInfo mi = this.GetType().GetMethod(methodname, BindingFlags.Instance | BindingFlags.NonPublic);
                    if (mi != null)
                    {
                        mi.Invoke(this, new object[] { btn.Text, null });
                    }
                }
                catch (Exception)
                {
                    // 若是出现错误  表明此菜单失效。不弹出错误提示。
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 保存常用菜单项
            string strCustom = "";
            foreach (ButtonItem btn in ribbonBarCustom.Items)
            {
                strCustom += btn.Name + ",";
            }
            UtilityClass.RWini.WriteIni("Menu", "Custom", strCustom, FormBooks.pathLogin);

            if (DialogResult.Yes != MessageBox.Show(this, "确定要退出当前程序吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                e.Cancel = true;
        }

        private void tsb1Calc_Click(object sender, EventArgs e)
        {
            Process.Start("Calc.exe");
        }

        private void tsb1Notepad_Click(object sender, EventArgs e)
        {
            Process.Start("Notepad.exe");
        }

        private void tsb1Mspaint_Click(object sender, EventArgs e)
        {
            Process.Start("Mspaint.exe");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ribbonBarCustom.ItemAdded += (o, v) =>
            {
                if (!ribbonBarCustom.Visible)
                    ribbonBarCustom.Visible = true;
                // 90 不是魔数，它是空隙加上 免费版本 的宽度
                ribbonBarCustom.Width = Width - ribbonBar11.Width - 90;
            };
            ribbonBarCustom.ItemRemoved += (o, v) =>
            {
                // 如果最终一个常用功能也没 隐藏容器
                if (ribbonBarCustom.Items.Count == 0)
                    ribbonBarCustom.Visible = false;
                else
                    // 90 不是魔数，它是空隙加上 免费版本 的宽度
                    ribbonBarCustom.Width = Width - ribbonBar11.Width - 90;
            };

            // 加载常用项
            string[] strCustom = UtilityClass.RWini.ReadIni("Menu", "Custom", FormBooks.pathLogin).Trim(' ', ',').Split(',');
            if (strCustom.Length > 0)
            {
                foreach (string str in strCustom)
                {
                    rtiAdd(str);
                }
            }

            // 代码移到事件里执行
            //// 如果最终一个常用功能也没 隐藏容器
            //if (ribbonBarCustom.Items.Count == 0)
            //    ribbonBarCustom.Visible = false;
            //else
            //    // 90 不是魔数，它是空隙加上 免费版本 的宽度
            //    ribbonBarCustom.Width = Width - ribbonBar11.Width - 90;
        }

        /// <summary>
        /// 用反射加载
        /// </summary>
        /// <param name="str">加载项的名称</param>
        public void rtiAdd(string str)
        {
            rtiAdd(ribbonBarCustom.Items.Count, str);

            //if (str.Length > 4)
            //{
            //    FieldInfo fi = this.GetType().GetField("tsb1" + str.Substring(4), BindingFlags.NonPublic | BindingFlags.Instance);
            //    if (fi != null)
            //    {
            //        ButtonItem temp = fi.GetValue(this) as ButtonItem;
            //        ButtonItem btn = new ButtonItem("tsb2" + str.Substring(4));
            //        btn.Click += (o, v) => TabAdd(o, "Frm" + str.Substring(4));
            //        btn.Image = temp.Image;
            //        btn.ImagePosition = eImagePosition.Top;
            //        btn.Text = temp.Text;
            //        ribbonBarCustom.Items.Add(btn);
            //    }
            //}
        }

        public void rtiAdd(int index, string str)
        {
            if (str.Length > 4)
            {
                FieldInfo fi = this.GetType().GetField("tsb1" + str.Substring(4), BindingFlags.NonPublic | BindingFlags.Instance);
                if (fi != null)
                {
                    ButtonItem temp = fi.GetValue(this) as ButtonItem;
                    ButtonItem btn = new ButtonItem("tsb2" + str.Substring(4));
                    btn.Click += (o, v) => TabAdd(o, "Frm" + str.Substring(4));
                    btn.Image = temp.Image;
                    btn.ImagePosition = eImagePosition.Top;
                    btn.Text = temp.Text;
                    // 不知道用插入形式会不会慢
                    //if (index < 0)
                    //    ribbonBarCustom.Items.Add(btn);
                    //else
                    ribbonBarCustom.Items.Insert(index, btn);
                }
            }
        }

        private void tsb1Custom_Click(object sender, EventArgs e)
        {
            FrmCustom fr = new FrmCustom(ribbonControl1);
            if (fr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // ... 改变常用功能项
            }
        }

        private void tsb1Update_Click(object sender, EventArgs e)
        {
            FSLib.App.SimpleUpdater.Updater.CheckUpdateSimple();
        }

        // 此方法已过时，它是针对菜单来辨别的
        ///// <summary>
        ///// 调用此方法以打开一个窗体
        /////  如果窗体已打开 将激活已打开窗体
        /////  
        ///// 当载入出错时，一定要注意命名空间是否为 StockReport.WinForm
        ///// </summary>
        //public void TabAdd(object sender, string frmName)
        //{
        //    ToolStripMenuItem tsm = sender as ToolStripMenuItem;
        //    if (tsm != null)
        //        TabAdd(tsm.Text, frmName);
        //    else if (sender != null)
        //        TabAdd(sender.ToString(), frmName);
        //}

        /// <summary>
        /// 调用此方法以打开一个窗体
        ///  如果窗体已打开 将激活已打开窗体
        /// </summary>
        /// <param name="sender">直接写 sender 即可</param>
        /// <param name="frmName">被调用窗体名称 统一为 Frm + 菜单名称第四个以后的字符</param>
        public void TabAdd(object sender, string frmName)
        {
            ButtonItem btn = sender as ButtonItem;
            if (btn != null)
                TabAdd(btn.Text, frmName);
        }

        /// <summary>
        /// 调用此方法以打开一个窗体
        ///  如果窗体已打开 将激活已打开窗体
        ///  
        /// 当载入出错时，一定要注意命名空间是否为 StockReport.WinForm
        /// </summary>
        /// <param name="title">显示名称</param>
        /// <param name="frmName">窗体Name</param>
        public void TabAdd(string title, string frmName)
        {
            foreach (TabItem item in tabControl1.Tabs)
            {
                if (item.AttachedControl.Controls.Count > 0 && item.AttachedControl.Controls[0].Name == frmName)
                {
                    tabControl1.SelectedTab = item;
                    return;
                }
            }
            TabItem ti = tabControl1.CreateTab(title);
            TabControlPanel tcp = new TabControlPanel();
            ti.AttachedControl = tcp;
            tcp.Dock = DockStyle.Fill;
            tcp.TabItem = ti;
            FormBase frm = (FormBase)Assembly.Load("StockReport").CreateInstance("StockReport.WinForm." + frmName);
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Name = frmName;
            frm.TopLevel = false;
            frm.Show();
            tcp.Controls.Add(frm);
            tabControl1.Controls.Add(tcp);
            tabControl1.SelectedTab = ti;
        }

        private void tsb1Employee_Click(object sender, EventArgs e)
        {
            TabAdd(sender, "FrmEmployee");
        }

        private void tsb1SysLog_Click(object sender, EventArgs e)
        {
            TabAdd(sender, "FrmLog");
        }

        private void tsb1Stock_Click(object sender, EventArgs e)
        {
            TabAdd(sender, "FrmStock");
        }

        private void tsb1StockIn_Click(object sender, EventArgs e)
        {
            TabAdd(sender, "FrmStockIn");
        }

        private void tsb1StockOut_Click(object sender, EventArgs e)
        {
            TabAdd(sender, "FrmStockOut");
        }

        private void tsb1StockAllocate_Click(object sender, EventArgs e)
        {
            TabAdd(sender, "FrmStockAllocate");
        }

        private void tsb1StockTaking_Click(object sender, EventArgs e)
        {
            TabAdd(sender, "FrmStockTaking");
        }

        private void tsb1StockAssembly_Click(object sender, EventArgs e)
        {
            TabAdd(sender, "FrmStockAssembly");
        }


    }
}
