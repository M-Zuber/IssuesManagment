namespace IssuesManagment.UI.POC
{
    partial class Issue
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IssueTitle = new System.Windows.Forms.Label();
            this.IssueBody = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IssueTitle
            // 
            this.IssueTitle.AutoSize = true;
            this.IssueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IssueTitle.Location = new System.Drawing.Point(4, 4);
            this.IssueTitle.Name = "IssueTitle";
            this.IssueTitle.Size = new System.Drawing.Size(0, 25);
            this.IssueTitle.TabIndex = 0;
            // 
            // IssueBody
            // 
            this.IssueBody.AutoSize = true;
            this.IssueBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IssueBody.Location = new System.Drawing.Point(4, 42);
            this.IssueBody.Name = "IssueBody";
            this.IssueBody.Size = new System.Drawing.Size(0, 20);
            this.IssueBody.TabIndex = 1;
            // 
            // Issue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.IssueBody);
            this.Controls.Add(this.IssueTitle);
            this.Name = "Issue";
            this.Size = new System.Drawing.Size(150, 87);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IssueTitle;
        private System.Windows.Forms.Label IssueBody;

    }
}
