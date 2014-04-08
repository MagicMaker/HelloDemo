namespace StockReport.WinForm
{
    partial class FrmSysLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFind = new DevComponents.DotNetBar.ButtonX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboList2 = new UtilityClass.ComboList();
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.comboList1 = new UtilityClass.ComboList();
            this.dgvBase1 = new UtilityClass.DgvBase();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.textBoxX2);
            this.panel1.Controls.Add(this.comboList2);
            this.panel1.Controls.Add(this.textBoxX1);
            this.panel1.Controls.Add(this.comboList1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 48);
            this.panel1.TabIndex = 0;
            // 
            // btnFind
            // 
            this.btnFind.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFind.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFind.Location = new System.Drawing.Point(532, 13);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "查找(&F)";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // textBoxX2
            // 
            // 
            // 
            // 
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Location = new System.Drawing.Point(347, 14);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.Size = new System.Drawing.Size(100, 21);
            this.textBoxX2.TabIndex = 3;
            // 
            // comboList2
            // 
            this.comboList2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.comboList2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.comboList2.Location = new System.Drawing.Point(243, 13);
            this.comboList2.Name = "comboList2";
            this.comboList2.Size = new System.Drawing.Size(98, 23);
            this.comboList2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboList2.TabIndex = 2;
            this.comboList2.Text = "comboList2";
            // 
            // textBoxX1
            // 
            // 
            // 
            // 
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Location = new System.Drawing.Point(131, 13);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.Size = new System.Drawing.Size(100, 21);
            this.textBoxX1.TabIndex = 1;
            // 
            // comboList1
            // 
            this.comboList1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.comboList1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.comboList1.Location = new System.Drawing.Point(27, 12);
            this.comboList1.Name = "comboList1";
            this.comboList1.Size = new System.Drawing.Size(98, 23);
            this.comboList1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboList1.TabIndex = 0;
            this.comboList1.Text = "comboList1";
            // 
            // dgvBase1
            // 
            this.dgvBase1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBase1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBase1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBase1.Location = new System.Drawing.Point(42, 80);
            this.dgvBase1.Name = "dgvBase1";
            this.dgvBase1.RowTemplate.Height = 23;
            this.dgvBase1.Size = new System.Drawing.Size(490, 237);
            this.dgvBase1.TabIndex = 1;
            // 
            // FrmLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 442);
            this.Controls.Add(this.dgvBase1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "FrmLog";
            this.Text = "FrmLog";
            this.Load += new System.EventHandler(this.FrmLog_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnFind;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private UtilityClass.ComboList comboList2;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private UtilityClass.ComboList comboList1;
        private UtilityClass.DgvBase dgvBase1;
    }
}