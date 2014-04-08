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

        private void tsb1Custom_Click(object sender, EventArgs e)
        {
            FrmCustom fr = new FrmCustom(ribbonControl1.Items);
            if (fr.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // ... 改变常用功能项
            }
        }

        private void tsb1Update_Click(object sender, EventArgs e)
        {
            FSLib.App.SimpleUpdater.Updater.CheckUpdateSimple();
        }

        public void TabAdd(object sender, string frmName)
        {
            ToolStripMenuItem tsm = sender as ToolStripMenuItem;
            if (tsm != null)
                TabAdd(tsm.Text, frmName);
            else if (sender != null)
                TabAdd(sender.ToString(), frmName);
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
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Dock = DockStyle.Fill;
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


    }
}
