namespace StockReport.WinForm
{
    partial class FrmStockAllocate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvBaseEx1 = new UtilityClass.DgvBaseEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseEx1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvBaseEx1
            // 
            this.dgvBaseEx1.AllowUserToOrderColumns = true;
            this.dgvBaseEx1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBaseEx1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBaseEx1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvBaseEx1.Location = new System.Drawing.Point(54, 58);
            this.dgvBaseEx1.Name = "dgvBaseEx1";
            this.dgvBaseEx1.RowTemplate.Height = 23;
            this.dgvBaseEx1.Size = new System.Drawing.Size(266, 253);
            this.dgvBaseEx1.TabIndex = 0;
            // 
            // FrmStockAllocate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 442);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvBaseEx1);
            this.DoubleBuffered = true;
            this.Name = "FrmStockAllocate";
            this.Text = "FrmStockAllocate";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseEx1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UtilityClass.DgvBaseEx dgvBaseEx1;
        private System.Windows.Forms.Button button1;
    }
}