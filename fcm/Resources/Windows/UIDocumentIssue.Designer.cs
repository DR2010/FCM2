namespace fcm.Windows
{
    partial class UIDocumentIssue
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
            this.txtUID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFKDocumentUID = new System.Windows.Forms.TextBox();
            this.txtFKDocumentCUID = new System.Windows.Forms.TextBox();
            this.txtIssueNumber = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLocation = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUID
            // 
            this.txtUID.Enabled = false;
            this.txtUID.Location = new System.Drawing.Point(108, 15);
            this.txtUID.Name = "txtUID";
            this.txtUID.ReadOnly = true;
            this.txtUID.Size = new System.Drawing.Size(100, 20);
            this.txtUID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "UID:";
            // 
            // txtFKDocumentUID
            // 
            this.txtFKDocumentUID.Enabled = false;
            this.txtFKDocumentUID.Location = new System.Drawing.Point(108, 41);
            this.txtFKDocumentUID.Name = "txtFKDocumentUID";
            this.txtFKDocumentUID.ReadOnly = true;
            this.txtFKDocumentUID.Size = new System.Drawing.Size(100, 20);
            this.txtFKDocumentUID.TabIndex = 2;
            // 
            // txtFKDocumentCUID
            // 
            this.txtFKDocumentCUID.Enabled = false;
            this.txtFKDocumentCUID.Location = new System.Drawing.Point(108, 67);
            this.txtFKDocumentCUID.Name = "txtFKDocumentCUID";
            this.txtFKDocumentCUID.ReadOnly = true;
            this.txtFKDocumentCUID.Size = new System.Drawing.Size(100, 20);
            this.txtFKDocumentCUID.TabIndex = 3;
            // 
            // txtIssueNumber
            // 
            this.txtIssueNumber.Enabled = false;
            this.txtIssueNumber.Location = new System.Drawing.Point(108, 93);
            this.txtIssueNumber.Name = "txtIssueNumber";
            this.txtIssueNumber.ReadOnly = true;
            this.txtIssueNumber.Size = new System.Drawing.Size(100, 20);
            this.txtIssueNumber.TabIndex = 4;
            // 
            // txtLocation
            // 
            this.txtLocation.Enabled = false;
            this.txtLocation.Location = new System.Drawing.Point(108, 119);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(333, 76);
            this.txtLocation.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Document UID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Document CUID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Issue Number:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(108, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(27, 119);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(75, 23);
            this.btnLocation.TabIndex = 12;
            this.btnLocation.Text = "Location...";
            this.btnLocation.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(341, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "New Issue Number:";
            // 
            // UIDocumentIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 240);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLocation);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtIssueNumber);
            this.Controls.Add(this.txtFKDocumentCUID);
            this.Controls.Add(this.txtFKDocumentUID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUID);
            this.Name = "UIDocumentIssue";
            this.Text = "Save Last Document Issue and Create new one";
            this.Load += new System.EventHandler(this.UIDocumentIssue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFKDocumentUID;
        private System.Windows.Forms.TextBox txtFKDocumentCUID;
        private System.Windows.Forms.TextBox txtIssueNumber;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
    }
}