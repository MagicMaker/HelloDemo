namespace StockReport
{
    partial class FrmCustomes
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
            this.qatCustomizePanel1 = new DevComponents.DotNetBar.Ribbon.QatCustomizePanel();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // qatCustomizePanel1
            // 
            this.qatCustomizePanel1.BackColor = System.Drawing.Color.Transparent;
            this.qatCustomizePanel1.Location = new System.Drawing.Point(12, 12);
            this.qatCustomizePanel1.Name = "qatCustomizePanel1";
            this.qatCustomizePanel1.Size = new System.Drawing.Size(444, 325);
            this.qatCustomizePanel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(368, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 33);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(22, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(118, 18);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "添加菜单到常用项：";
            // 
            // FrmCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 349);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.qatCustomizePanel1);
            this.DoubleBuffered = true;
            this.Name = "FrmCustom";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加到常用项";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCustom_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Ribbon.QatCustomizePanel qatCustomizePanel1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.LabelX labelX1;

    }
}