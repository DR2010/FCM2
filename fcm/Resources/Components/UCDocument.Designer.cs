namespace fcm.Components
{
    partial class UCDocument
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
            this.txtCUID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.txtSubDirectory = new System.Windows.Forms.TextBox();
            this.txtSeqNum = new System.Windows.Forms.TextBox();
            this.txtLatestIssueNumber = new System.Windows.Forms.TextBox();
            this.txtLatestIssueLocation = new System.Windows.Forms.TextBox();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCUID
            // 
            this.txtCUID.Enabled = false;
            this.txtCUID.Location = new System.Drawing.Point(137, 20);
            this.txtCUID.Name = "txtCUID";
            this.txtCUID.ReadOnly = true;
            this.txtCUID.Size = new System.Drawing.Size(100, 20);
            this.txtCUID.TabIndex = 0;
            this.txtCUID.TextChanged += new System.EventHandler(this.txtCUID_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(137, 46);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(232, 57);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(137, 109);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(100, 20);
            this.txtDirectory.TabIndex = 2;
            this.txtDirectory.TextChanged += new System.EventHandler(this.txtDirectory_TextChanged);
            // 
            // txtSubDirectory
            // 
            this.txtSubDirectory.Location = new System.Drawing.Point(137, 135);
            this.txtSubDirectory.Name = "txtSubDirectory";
            this.txtSubDirectory.Size = new System.Drawing.Size(100, 20);
            this.txtSubDirectory.TabIndex = 3;
            this.txtSubDirectory.TextChanged += new System.EventHandler(this.txtSubDirectory_TextChanged);
            // 
            // txtSeqNum
            // 
            this.txtSeqNum.Location = new System.Drawing.Point(137, 161);
            this.txtSeqNum.Name = "txtSeqNum";
            this.txtSeqNum.Size = new System.Drawing.Size(100, 20);
            this.txtSeqNum.TabIndex = 4;
            this.txtSeqNum.TextChanged += new System.EventHandler(this.txtSeqNum_TextChanged);
            // 
            // txtLatestIssueNumber
            // 
            this.txtLatestIssueNumber.Location = new System.Drawing.Point(137, 187);
            this.txtLatestIssueNumber.Name = "txtLatestIssueNumber";
            this.txtLatestIssueNumber.Size = new System.Drawing.Size(100, 20);
            this.txtLatestIssueNumber.TabIndex = 5;
            this.txtLatestIssueNumber.TextChanged += new System.EventHandler(this.txtLatestIssueNumber_TextChanged);
            // 
            // txtLatestIssueLocation
            // 
            this.txtLatestIssueLocation.Location = new System.Drawing.Point(137, 213);
            this.txtLatestIssueLocation.Multiline = true;
            this.txtLatestIssueLocation.Name = "txtLatestIssueLocation";
            this.txtLatestIssueLocation.Size = new System.Drawing.Size(232, 56);
            this.txtLatestIssueLocation.TabIndex = 6;
            this.txtLatestIssueLocation.TextChanged += new System.EventHandler(this.txtLatestIssueLocation_TextChanged);
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(137, 273);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(232, 45);
            this.txtComments.TabIndex = 7;
            this.txtComments.TextChanged += new System.EventHandler(this.txtComments_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "UID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Directory:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Sub Directory:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Seq Num:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Issue:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Comments:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(213, 324);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 16;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(294, 324);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 17;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(63, 213);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(68, 19);
            this.btnOpenFile.TabIndex = 18;
            this.btnOpenFile.Text = "Location...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // UCDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.Save);
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
            this.Name = "UCDocument";
            this.Size = new System.Drawing.Size(375, 353);
            this.Load += new System.EventHandler(this.UCDocument_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCUID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.TextBox txtSubDirectory;
        private System.Windows.Forms.TextBox txtSeqNum;
        private System.Windows.Forms.TextBox txtLatestIssueNumber;
        private System.Windows.Forms.TextBox txtLatestIssueLocation;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenFile;
    }
}
