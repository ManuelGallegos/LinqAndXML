namespace WindowsFormsApplication1
{
    partial class LinqToSQL
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
            this.txtLinqToSql = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLinqToSql
            // 
            this.txtLinqToSql.Location = new System.Drawing.Point(62, 67);
            this.txtLinqToSql.Multiline = true;
            this.txtLinqToSql.Name = "txtLinqToSql";
            this.txtLinqToSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLinqToSql.Size = new System.Drawing.Size(448, 312);
            this.txtLinqToSql.TabIndex = 0;
            // 
            // LinqToSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 439);
            this.Controls.Add(this.txtLinqToSql);
            this.Name = "LinqToSQL";
            this.Text = "LinqToSQL";
            this.Load += new System.EventHandler(this.LinqToSQL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLinqToSql;
    }
}