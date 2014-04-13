namespace StockReport
{
    partial class FrmCustom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustom));
            this.treeLeft = new System.Windows.Forms.TreeView();
            this.btnFind = new DevComponents.DotNetBar.ButtonX();
            this.comFind = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnRemove = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnUp = new DevComponents.DotNetBar.ButtonX();
            this.btnDown = new DevComponents.DotNetBar.ButtonX();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listRight = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // treeLeft
            // 
            this.treeLeft.ImageIndex = 0;
            this.treeLeft.ImageList = this.imageList1;
            this.treeLeft.Location = new System.Drawing.Point(12, 57);
            this.treeLeft.Name = "treeLeft";
            this.treeLeft.SelectedImageIndex = 1;
            this.treeLeft.Size = new System.Drawing.Size(179, 280);
            this.treeLeft.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFind.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFind.Image = global::StockReport.Properties.Resources.search_16;
            this.btnFind.Location = new System.Drawing.Point(166, 29);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(25, 23);
            this.btnFind.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFind.TabIndex = 7;
            // 
            // comFind
            // 
            this.comFind.DisplayMember = "Text";
            this.comFind.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comFind.FormattingEnabled = true;
            this.comFind.ItemHeight = 15;
            this.comFind.Location = new System.Drawing.Point(12, 30);
            this.comFind.Name = "comFind";
            this.comFind.Size = new System.Drawing.Size(151, 21);
            this.comFind.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comFind.TabIndex = 5;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(11, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(118, 18);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "添加菜单到常用项：";
            // 
            // btnRemove
            // 
            this.btnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRemove.Location = new System.Drawing.Point(196, 148);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(83, 21);
            this.btnRemove.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "<<";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(196, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 21);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = ">>";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(378, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 33);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Visible = false;
            // 
            // btnUp
            // 
            this.btnUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUp.Location = new System.Drawing.Point(258, 185);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(21, 38);
            this.btnUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "∧∧";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDown.Location = new System.Drawing.Point(258, 231);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(21, 38);
            this.btnDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "∨∨";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "appgroup.png");
            this.imageList1.Images.SetKeyName(1, "Action_Open.png");
            this.imageList1.Images.SetKeyName(2, "WinForms2.png");
            this.imageList1.Images.SetKeyName(3, "tree_region.png");
            // 
            // listRight
            // 
            this.listRight.FormattingEnabled = true;
            this.listRight.ItemHeight = 12;
            this.listRight.Location = new System.Drawing.Point(285, 57);
            this.listRight.Name = "listRight";
            this.listRight.Size = new System.Drawing.Size(179, 280);
            this.listRight.TabIndex = 8;
            // 
            // FrmCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 349);
            this.Controls.Add(this.listRight);
            this.Controls.Add(this.treeLeft);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.comFind);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Name = "FrmCustom";
            this.Text = "添加到常用项";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comFind;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnRemove;
        private DevComponents.DotNetBar.ButtonX btnFind;
        private System.Windows.Forms.TreeView treeLeft;
        private DevComponents.DotNetBar.ButtonX btnUp;
        private DevComponents.DotNetBar.ButtonX btnDown;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListBox listRight;
    }
}