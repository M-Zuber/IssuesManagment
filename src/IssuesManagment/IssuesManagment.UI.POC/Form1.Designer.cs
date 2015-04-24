namespace IssuesManagment.UI.POC
{
    partial class Form1
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
            this.Issues = new System.Windows.Forms.Panel();
            this.GetIssues = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Issues
            // 
            this.Issues.AutoScroll = true;
            this.Issues.Dock = System.Windows.Forms.DockStyle.Top;
            this.Issues.Location = new System.Drawing.Point(0, 0);
            this.Issues.Name = "Issues";
            this.Issues.Size = new System.Drawing.Size(926, 218);
            this.Issues.TabIndex = 0;
            // 
            // GetIssues
            // 
            this.GetIssues.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GetIssues.Location = new System.Drawing.Point(12, 238);
            this.GetIssues.Name = "GetIssues";
            this.GetIssues.Size = new System.Drawing.Size(75, 23);
            this.GetIssues.TabIndex = 1;
            this.GetIssues.Text = "Get Issues";
            this.GetIssues.UseVisualStyleBackColor = true;
            this.GetIssues.Click += new System.EventHandler(this.GetIssues_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 285);
            this.Controls.Add(this.GetIssues);
            this.Controls.Add(this.Issues);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Issues;
        private System.Windows.Forms.Button GetIssues;
    }
}

