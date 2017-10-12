namespace WindowsFormsApplication1
{
    partial class LinqOverview
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
            this.txtOverview = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtOverview
            // 
            this.txtOverview.Location = new System.Drawing.Point(64, 61);
            this.txtOverview.Multiline = true;
            this.txtOverview.Name = "txtOverview";
            this.txtOverview.Size = new System.Drawing.Size(716, 508);
            this.txtOverview.TabIndex = 0;
            // 
            // LinqOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 611);
            this.Controls.Add(this.txtOverview);
            this.Name = "LinqOverview";
            this.Text = "LinqOverview";
            this.Load += new System.EventHandler(this.LinqOverview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOverview;
    }
}