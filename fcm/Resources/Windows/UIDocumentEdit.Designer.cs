namespace fcm.Windows
{
    partial class UIDocumentEdit
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
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtLatestIssueLocation = new System.Windows.Forms.TextBox();
            this.txtLatestIssueNumber = new System.Windows.Forms.TextBox();
            this.txtSeqNum = new System.Windows.Forms.TextBox();
            this.txtSubDirectory = new System.Windows.Forms.TextBox();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCUID = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewIssue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(29, 207);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(68, 24);
            this.btnOpenFile.TabIndex = 36;
            this.btnOpenFile.Text = "Location...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(181, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(102, 318);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 34;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Comments:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Issue:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Seq Num:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Sub Directory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "UID:";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(103, 267);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(232, 45);
            this.txtComments.TabIndex = 26;
            // 
            // txtLatestIssueLocation
            // 
            this.txtLatestIssueLocation.Location = new System.Drawing.Point(103, 207);
            this.txtLatestIssueLocation.Multiline = true;
            this.txtLatestIssueLocation.Name = "txtLatestIssueLocation";
            this.txtLatestIssueLocation.Size = new System.Drawing.Size(232, 56);
            this.txtLatestIssueLocation.TabIndex = 25;
            // 
            // txtLatestIssueNumber
            // 
            this.txtLatestIssueNumber.Enabled = false;
            this.txtLatestIssueNumber.Location = new System.Drawing.Point(103, 181);
            this.txtLatestIssueNumber.Name = "txtLatestIssueNumber";
            this.txtLatestIssueNumber.ReadOnly = true;
            this.txtLatestIssueNumber.Size = new System.Drawing.Size(100, 20);
            this.txtLatestIssueNumber.TabIndex = 24;
            // 
            // txtSeqNum
            // 
            this.txtSeqNum.Location = new System.Drawing.Point(103, 155);
            this.txtSeqNum.Name = "txtSeqNum";
            this.txtSeqNum.Size = new System.Drawing.Size(100, 20);
            this.txtSeqNum.TabIndex = 23;
            // 
            // txtSubDirectory
            // 
            this.txtSubDirectory.Location = new System.Drawing.Point(103, 129);
            this.txtSubDirectory.Name = "txtSubDirectory";
            this.txtSubDirectory.Size = new System.Drawing.Size(100, 20);
            this.txtSubDirectory.TabIndex = 22;
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(103, 103);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(100, 20);
            this.txtDirectory.TabIndex = 21;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(103, 40);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(232, 57);
            this.txtName.TabIndex = 20;
            // 
            // txtCUID
            // 
            this.txtCUID.Enabled = false;
            this.txtCUID.Location = new System.Drawing.Point(103, 14);
            this.txtCUID.Name = "txtCUID";
            this.txtCUID.ReadOnly = true;
            this.txtCUID.Size = new System.Drawing.Size(100, 20);
            this.txtCUID.TabIndex = 19;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(260, 318);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 37;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNewIssue
            // 
            this.btnNewIssue.Location = new System.Drawing.Point(209, 180);
            this.btnNewIssue.Name = "btnNewIssue";
            this.btnNewIssue.Size = new System.Drawing.Size(75, 21);
            this.btnNewIssue.TabIndex = 38;
            this.btnNewIssue.Text = "New Issue";
            this.btnNewIssue.UseVisualStyleBackColor = true;
            this.btnNewIssue.Click += new System.EventHandler(this.btnNewIssue_Click);
            // 
            // UIDocumentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 360);
            this.Controls.Add(this.btnNewIssue);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtLatestIssueLocation);
            this.Controls.Add(this.txtLatestIssueNumber);
            this.Controls.Add(this.txtSeqNum);
            this.Controls.Add(this.txtSubDirectory);
            this.Controls.Add(this.txtDirectory);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCUID);
            this.Name = "UIDocumentEdit";
            this.Text = "Edit Document";
            this.Load += new System.EventHandler(this.UIDocumentEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtLatestIssueLocation;
        private System.Windows.Forms.TextBox txtLatestIssueNumber;
        private System.Windows.Forms.TextBox txtSeqNum;
        private System.Windows.Forms.TextBox txtSubDirectory;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCUID;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNewIssue;
    }
}