namespace WindowsFormsApplication1
{
    partial class SQLToXML
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
            this.txtSQLToXML = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSQLToXML
            // 
            this.txtSQLToXML.Location = new System.Drawing.Point(111, 77);
            this.txtSQLToXML.Multiline = true;
            this.txtSQLToXML.Name = "txtSQLToXML";
            this.txtSQLToXML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSQLToXML.Size = new System.Drawing.Size(674, 460);
            this.txtSQLToXML.TabIndex = 0;
            // 
            // SQLToXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 617);
            this.Controls.Add(this.txtSQLToXML);
            this.Name = "SQLToXML";
            this.Text = "SQLToXML";
            this.Load += new System.EventHandler(this.SQLToXML_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSQLToXML;
    }
}