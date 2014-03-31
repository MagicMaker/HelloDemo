namespace StockReport
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtUserPwd = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comUserId = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(186, 209);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 33);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定(&O)";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX1.Location = new System.Drawing.Point(84, 138);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(87, 26);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "登录名：";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Far;
            this.labelX1.DoubleClick += new System.EventHandler(this.labelX1_DoubleClick);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX2.Location = new System.Drawing.Point(84, 175);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(87, 26);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "密码：";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // txtUserPwd
            // 
            // 
            // 
            // 
            this.txtUserPwd.Border.Class = "TextBoxBorder";
            this.txtUserPwd.Font = new System.Drawing.Font("宋体", 12F);
            this.txtUserPwd.Location = new System.Drawing.Point(177, 175);
            this.txtUserPwd.Name = "txtUserPwd";
            this.txtUserPwd.PasswordChar = '●';
            this.txtUserPwd.Size = new System.Drawing.Size(202, 26);
            this.txtUserPwd.TabIndex = 3;
            this.txtUserPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserPwd_KeyPress);
            this.txtUserPwd.TextChanged += new System.EventHandler(this.comUserId_TextChanged);
            // 
            // comUserId
            // 
            this.comUserId.DisplayMember = "Text";
            this.comUserId.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comUserId.Font = new System.Drawing.Font("宋体", 12F);
            this.comUserId.FormattingEnabled = true;
            this.comUserId.ItemHeight = 20;
            this.comUserId.Location = new System.Drawing.Point(177, 138);
            this.comUserId.Name = "comUserId";
            this.comUserId.Size = new System.Drawing.Size(202, 26);
            this.comUserId.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comUserId.TabIndex = 1;
            this.comUserId.SelectedIndexChanged += new System.EventHandler(this.comUserId_SelectedIndexChanged);
            this.comUserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comUserId_KeyPress);
            this.comUserId.TextChanged += new System.EventHandler(this.comUserId_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            //this.pictureBox1.Image = global::cn.bway.data.ERPBase.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(477, 118);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 262);
            this.Controls.Add(this.comUserId);
            this.Controls.Add(this.txtUserPwd);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录...";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUserPwd;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comUserId;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}