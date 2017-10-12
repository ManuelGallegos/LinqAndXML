namespace WindowsFormsApplication1
{
    partial class LinqToXml
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
            this.txtLinqToXml = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLinqToXml
            // 
            this.txtLinqToXml.Location = new System.Drawing.Point(99, 63);
            this.txtLinqToXml.Multiline = true;
            this.txtLinqToXml.Name = "txtLinqToXml";
            this.txtLinqToXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLinqToXml.Size = new System.Drawing.Size(919, 562);
            this.txtLinqToXml.TabIndex = 0;
            // 
            // LinqToXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 737);
            this.Controls.Add(this.txtLinqToXml);
            this.Name = "LinqToXml";
            this.Text = "LinqToXml";
            this.Load += new System.EventHandler(this.LinqToXml_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLinqToXml;
    }
}