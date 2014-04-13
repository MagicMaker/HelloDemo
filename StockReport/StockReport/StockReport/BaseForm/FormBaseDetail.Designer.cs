namespace StockReport
{
    partial class FormBaseDetail
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
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.SuspendLayout();
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            // 
            // FormBaseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 442);
            this.DoubleBuffered = true;
            this.Name = "FormBaseDetail";
            this.Text = "FormBaseDetail";
            this.ResumeLayout(false);

        }

        #endregion

        protected internal DevComponents.DotNetBar.Validator.Highlighter highlighter1;

    }
}