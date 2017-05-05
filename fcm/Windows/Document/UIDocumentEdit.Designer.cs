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
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDocumentUID = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtIssueNumber = new System.Windows.Forms.TextBox();
            this.txtSeqNum = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCUID = new System.Windows.Forms.TextBox();
            this.btnNewIssue = new System.Windows.Forms.Button();
            this.btnEditDocument = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxSourceCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClientUID = new System.Windows.Forms.TextBox();
            this.btnClient = new System.Windows.Forms.Button();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtParentUID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxRecordType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkProjectPlan = new System.Windows.Forms.CheckBox();
            this.cbxDocumentType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSimpleFileName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsSave = new System.Windows.Forms.ToolStripButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(12, 246);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(68, 24);
            this.btnOpenFile.TabIndex = 24;
            this.btnOpenFile.Text = "Location...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 353);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Comments:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Version:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Seq Num:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name:";
            // 
            // lblDocumentUID
            // 
            this.lblDocumentUID.AutoSize = true;
            this.lblDocumentUID.Location = new System.Drawing.Point(10, 65);
            this.lblDocumentUID.Name = "lblDocumentUID";
            this.lblDocumentUID.Size = new System.Drawing.Size(73, 13);
            this.lblDocumentUID.TabIndex = 1;
            this.lblDocumentUID.Text = "Document ID:";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(86, 350);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(454, 45);
            this.txtComments.TabIndex = 30;
            // 
            // txtLocation
            // 
            this.txtLocation.Enabled = false;
            this.txtLocation.Location = new System.Drawing.Point(86, 246);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Size = new System.Drawing.Size(454, 56);
            this.txtLocation.TabIndex = 25;
            // 
            // txtIssueNumber
            // 
            this.txtIssueNumber.Location = new System.Drawing.Point(86, 220);
            this.txtIssueNumber.MaxLength = 6;
            this.txtIssueNumber.Name = "txtIssueNumber";
            this.txtIssueNumber.Size = new System.Drawing.Size(100, 20);
            this.txtIssueNumber.TabIndex = 20;
            this.txtIssueNumber.TextChanged += new System.EventHandler(this.enableSave);
            // 
            // txtSeqNum
            // 
            this.txtSeqNum.Enabled = false;
            this.txtSeqNum.Location = new System.Drawing.Point(86, 194);
            this.txtSeqNum.MaxLength = 6;
            this.txtSeqNum.Name = "txtSeqNum";
            this.txtSeqNum.ReadOnly = true;
            this.txtSeqNum.Size = new System.Drawing.Size(34, 20);
            this.txtSeqNum.TabIndex = 13;
            this.txtSeqNum.TextChanged += new System.EventHandler(this.enableSave);
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(86, 132);
            this.txtName.MaxLength = 100;
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(454, 57);
            this.txtName.TabIndex = 11;
            this.txtName.TextChanged += new System.EventHandler(this.enableSave);
            // 
            // txtCUID
            // 
            this.txtCUID.Location = new System.Drawing.Point(86, 62);
            this.txtCUID.Name = "txtCUID";
            this.txtCUID.Size = new System.Drawing.Size(100, 20);
            this.txtCUID.TabIndex = 2;
            this.txtCUID.TextChanged += new System.EventHandler(this.enableSave);
            // 
            // btnNewIssue
            // 
            this.btnNewIssue.Location = new System.Drawing.Point(192, 219);
            this.btnNewIssue.Name = "btnNewIssue";
            this.btnNewIssue.Size = new System.Drawing.Size(92, 21);
            this.btnNewIssue.TabIndex = 21;
            this.btnNewIssue.Text = "New Version";
            this.btnNewIssue.UseVisualStyleBackColor = true;
            this.btnNewIssue.Click += new System.EventHandler(this.btnNewIssue_Click);
            // 
            // btnEditDocument
            // 
            this.btnEditDocument.Location = new System.Drawing.Point(546, 246);
            this.btnEditDocument.Name = "btnEditDocument";
            this.btnEditDocument.Size = new System.Drawing.Size(68, 24);
            this.btnEditDocument.TabIndex = 26;
            this.btnEditDocument.Text = "View...";
            this.btnEditDocument.UseVisualStyleBackColor = true;
            this.btnEditDocument.Click += new System.EventHandler(this.btnEditDocument_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(85, 308);
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(455, 37);
            this.txtFileName.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "File Name:";
            // 
            // cbxSourceCode
            // 
            this.cbxSourceCode.FormattingEnabled = true;
            this.cbxSourceCode.Items.AddRange(new object[] {
            "FCM",
            "CLIENT"});
            this.cbxSourceCode.Location = new System.Drawing.Point(290, 62);
            this.cbxSourceCode.Name = "cbxSourceCode";
            this.cbxSourceCode.Size = new System.Drawing.Size(120, 21);
            this.cbxSourceCode.TabIndex = 5;
            this.cbxSourceCode.SelectedIndexChanged += new System.EventHandler(this.cbxSourceCode_SelectedIndexChanged);
            this.cbxSourceCode.TextChanged += new System.EventHandler(this.enableSave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Source:";
            // 
            // txtClientUID
            // 
            this.txtClientUID.Enabled = false;
            this.txtClientUID.Location = new System.Drawing.Point(448, 62);
            this.txtClientUID.Name = "txtClientUID";
            this.txtClientUID.ReadOnly = true;
            this.txtClientUID.Size = new System.Drawing.Size(92, 20);
            this.txtClientUID.TabIndex = 7;
            // 
            // btnClient
            // 
            this.btnClient.Location = new System.Drawing.Point(416, 61);
            this.btnClient.Name = "btnClient";
            this.btnClient.Size = new System.Drawing.Size(26, 20);
            this.btnClient.TabIndex = 6;
            this.btnClient.Text = "...";
            this.btnClient.UseVisualStyleBackColor = true;
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);
            // 
            // txtUID
            // 
            this.txtUID.Enabled = false;
            this.txtUID.Location = new System.Drawing.Point(191, 62);
            this.txtUID.Name = "txtUID";
            this.txtUID.ReadOnly = true;
            this.txtUID.Size = new System.Drawing.Size(48, 20);
            this.txtUID.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.documentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // documentToolStripMenuItem
            // 
            this.documentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.documentToolStripMenuItem.Name = "documentToolStripMenuItem";
            this.documentToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.documentToolStripMenuItem.Text = "Document";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtParentUID
            // 
            this.txtParentUID.Enabled = false;
            this.txtParentUID.Location = new System.Drawing.Point(393, 195);
            this.txtParentUID.MaxLength = 6;
            this.txtParentUID.Name = "txtParentUID";
            this.txtParentUID.ReadOnly = true;
            this.txtParentUID.Size = new System.Drawing.Size(147, 20);
            this.txtParentUID.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(350, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Parent:";
            // 
            // cbxRecordType
            // 
            this.cbxRecordType.FormattingEnabled = true;
            this.cbxRecordType.Location = new System.Drawing.Point(372, 221);
            this.cbxRecordType.Name = "cbxRecordType";
            this.cbxRecordType.Size = new System.Drawing.Size(168, 21);
            this.cbxRecordType.TabIndex = 23;
            this.cbxRecordType.SelectedIndexChanged += new System.EventHandler(this.cbxRecordType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Record Type:";
            // 
            // checkProjectPlan
            // 
            this.checkProjectPlan.AutoSize = true;
            this.checkProjectPlan.Location = new System.Drawing.Point(127, 197);
            this.checkProjectPlan.Name = "checkProjectPlan";
            this.checkProjectPlan.Size = new System.Drawing.Size(83, 17);
            this.checkProjectPlan.TabIndex = 14;
            this.checkProjectPlan.Text = "Project Plan";
            this.checkProjectPlan.UseVisualStyleBackColor = true;
            // 
            // cbxDocumentType
            // 
            this.cbxDocumentType.FormattingEnabled = true;
            this.cbxDocumentType.Location = new System.Drawing.Point(262, 195);
            this.cbxDocumentType.Name = "cbxDocumentType";
            this.cbxDocumentType.Size = new System.Drawing.Size(82, 21);
            this.cbxDocumentType.TabIndex = 16;
            this.cbxDocumentType.SelectedIndexChanged += new System.EventHandler(this.cbxDocumentType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Type:";
            // 
            // txtSimpleFileName
            // 
            this.txtSimpleFileName.Location = new System.Drawing.Point(86, 89);
            this.txtSimpleFileName.Multiline = true;
            this.txtSimpleFileName.Name = "txtSimpleFileName";
            this.txtSimpleFileName.Size = new System.Drawing.Size(454, 37);
            this.txtSimpleFileName.TabIndex = 9;
            this.txtSimpleFileName.TextChanged += new System.EventHandler(this.txtSimpleFileName_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Simple Name:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.tsSave});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(671, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::fcm.Properties.Resources.ImageExit;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Exit";
            this.toolStripButton1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::fcm.Properties.Resources.ImageNew;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "New";
            this.toolStripButton2.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // tsSave
            // 
            this.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsSave.Image = global::fcm.Properties.Resources.Save;
            this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(23, 22);
            this.tsSave.Text = "toolStripButton3";
            this.tsSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 401);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Display Name:";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(86, 401);
            this.txtDisplayName.Multiline = true;
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(454, 37);
            this.txtDisplayName.TabIndex = 32;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(86, 444);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 24);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(160, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 24);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(234, 444);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(68, 24);
            this.btnNew.TabIndex = 35;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(546, 276);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 24);
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Text = "Edit...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // UIDocumentEdit
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(671, 470);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtSimpleFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxDocumentType);
            this.Controls.Add(this.checkProjectPlan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxRecordType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtParentUID);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.txtClientUID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxSourceCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnEditDocument);
            this.Controls.Add(this.btnNewIssue);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDocumentUID);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtIssueNumber);
            this.Controls.Add(this.txtSeqNum);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCUID);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UIDocumentEdit";
            this.Text = "Edit Document";
            this.Load += new System.EventHandler(this.UIDocumentEdit_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDocumentUID;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtIssueNumber;
        private System.Windows.Forms.TextBox txtSeqNum;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCUID;
        private System.Windows.Forms.Button btnNewIssue;
        private System.Windows.Forms.Button btnEditDocument;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxSourceCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClientUID;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.TextBox txtParentUID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxRecordType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkProjectPlan;
        private System.Windows.Forms.ComboBox cbxDocumentType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSimpleFileName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton tsSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
    }
}