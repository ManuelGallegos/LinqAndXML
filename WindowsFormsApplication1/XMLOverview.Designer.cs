namespace WindowsFormsApplication1
{
    partial class XMLOverview
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnGetXMLData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(117, 41);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(598, 548);
            this.txtResult.TabIndex = 0;
            // 
            // btnGetXMLData
            // 
            this.btnGetXMLData.Location = new System.Drawing.Point(321, 615);
            this.btnGetXMLData.Name = "btnGetXMLData";
            this.btnGetXMLData.Size = new System.Drawing.Size(175, 69);
            this.btnGetXMLData.TabIndex = 1;
            this.btnGetXMLData.Text = "Get XML Data";
            this.btnGetXMLData.UseVisualStyleBackColor = true;
            this.btnGetXMLData.Click += new System.EventHandler(this.btnGetXMLData_Click);
            // 
            // XML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 732);
            this.Controls.Add(this.btnGetXMLData);
            this.Controls.Add(this.txtResult);
            this.Name = "XML";
            this.Text = "XML";
            this.Load += new System.EventHandler(this.XML_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnGetXMLData;
    }
}